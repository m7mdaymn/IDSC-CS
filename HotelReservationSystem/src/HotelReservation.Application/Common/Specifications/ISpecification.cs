using System.Linq.Expressions;
using HotelReservation.Domain.Common;

namespace HotelReservation.Application.Common.Specifications;

public interface ISpecification<TEntity>
    where TEntity : BaseEntity
{
    Expression<Func<TEntity, bool>>? Criteria { get; }

    IReadOnlyList<Expression<Func<TEntity, object>>> Includes { get; }

    Expression<Func<TEntity, object>>? OrderBy { get; }

    Expression<Func<TEntity, object>>? OrderByDescending { get; }

    int Skip { get; }

    int Take { get; }

    bool IsPagingEnabled { get; }

    bool AsNoTracking { get; }

    bool IncludeSoftDeleted { get; }
}