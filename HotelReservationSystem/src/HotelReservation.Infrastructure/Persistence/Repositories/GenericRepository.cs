using HotelReservation.Application.Common.Interfaces.Persistence;
using HotelReservation.Application.Common.Specifications;
using HotelReservation.Domain.Common;
using HotelReservation.Infrastructure.Persistence.Specifications;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.Infrastructure.Persistence.Repositories;

internal sealed class GenericRepository<TEntity>
    : IGenericRepository<TEntity>
    where TEntity : BaseEntity
{
    private readonly DbSet<TEntity> _dbSet;

    public GenericRepository(
        HotelDbContext context)
    {
        _dbSet = context.Set<TEntity>();
    }


    public async Task<TEntity?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await GetQueryRoot()
            .FirstOrDefaultAsync(
                entity => entity.Id == id,
                cancellationToken);
    }


    public async Task<TEntity?> FirstOrDefaultAsync(
        ISpecification<TEntity> specification,
        CancellationToken cancellationToken = default)
    {
        return await ApplySpecification(
                specification)
            .FirstOrDefaultAsync(
                cancellationToken);
    }


    public async Task<IReadOnlyList<TEntity>> ListAsync(
        ISpecification<TEntity> specification,
        CancellationToken cancellationToken = default)
    {
        return await ApplySpecification(
                specification)
            .ToListAsync(
                cancellationToken);
    }


    public async Task<bool> AnyAsync(
        ISpecification<TEntity> specification,
        CancellationToken cancellationToken = default)
    {
        return await ApplySpecification(
                specification)
            .AnyAsync(
                cancellationToken);
    }


    public async Task<int> CountAsync(
        ISpecification<TEntity> specification,
        CancellationToken cancellationToken = default)
    {
        return await SpecificationEvaluator<TEntity>
            .GetQuery(
                GetQueryRoot(),
                specification,
                applyPaging: false)
            .CountAsync(
                cancellationToken);
    }


    public async Task AddAsync(
        TEntity entity,
        CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(
            entity,
            cancellationToken);
    }


    public void Update(
        TEntity entity)
    {
        _dbSet.Update(entity);
    }


    public void Remove(
        TEntity entity)
    {
        _dbSet.Remove(entity);
    }


    private IQueryable<TEntity> ApplySpecification(
        ISpecification<TEntity> specification)
    {
        return SpecificationEvaluator<TEntity>
            .GetQuery(
                GetQueryRoot(),
                specification);
    }


    private IQueryable<TEntity> GetQueryRoot()
    {
        var query =
            _dbSet.AsQueryable();

        if (typeof(ISoftDeletable)
            .IsAssignableFrom(typeof(TEntity)))
        {
            query =
                query.Where(entity =>
                    !EF.Property<bool>(
                        entity,
                        nameof(ISoftDeletable.IsDeleted)));
        }

        return query;
    }
}