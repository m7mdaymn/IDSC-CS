using HotelReservation.Domain.Common;

namespace HotelReservation.Application.Common.Interfaces.Persistence;

public interface IUnitOfWork
{
    IGenericRepository<TEntity> Repository<TEntity>()
        where TEntity : BaseEntity;

    Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default);
}