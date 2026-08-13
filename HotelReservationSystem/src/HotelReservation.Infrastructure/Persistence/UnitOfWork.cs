using HotelReservation.Application.Common.Interfaces.Persistence;
using HotelReservation.Domain.Common;
using HotelReservation.Infrastructure.Persistence.Repositories;

namespace HotelReservation.Infrastructure.Persistence;

internal sealed class UnitOfWork
    : IUnitOfWork
{
    private readonly HotelDbContext _context;

    private readonly Dictionary<Type, object>
        _repositories = new();

    public UnitOfWork(
        HotelDbContext context)
    {
        _context = context;
    }

    public IGenericRepository<TEntity> Repository<TEntity>()
        where TEntity : BaseEntity
    {
        var entityType =
            typeof(TEntity);

        if (_repositories.TryGetValue(
                entityType,
                out var repository))
        {
            return
                (IGenericRepository<TEntity>)repository;
        }

        var newRepository =
            new GenericRepository<TEntity>(
                _context);

        _repositories[entityType] =
            newRepository;

        return newRepository;
    }

    public Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(
            cancellationToken);
    }
    
}