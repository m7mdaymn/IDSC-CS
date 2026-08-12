using HotelReservation.Application.Common.Specifications;
using HotelReservation.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.Infrastructure.Persistence.Specifications;

internal static class SpecificationEvaluator<TEntity>
    where TEntity : BaseEntity
{
    public static IQueryable<TEntity> GetQuery(
        IQueryable<TEntity> inputQuery,
        ISpecification<TEntity> specification)
    {
        var query = inputQuery;

        if (specification.AsNoTracking)
        {
            query = query.AsNoTracking();
        }

        if (specification.Criteria is not null)
        {
            query = query.Where(
                specification.Criteria);
        }

        query = specification.Includes.Aggregate(
            query,
            (current, include) =>
                current.Include(include));

        if (specification.OrderBy is not null)
        {
            query = query.OrderBy(
                specification.OrderBy);
        }
        else if (
            specification.OrderByDescending is not null)
        {
            query = query.OrderByDescending(
                specification.OrderByDescending);
        }

        if (specification.IsPagingEnabled)
        {
            query = query
                .Skip(specification.Skip)
                .Take(specification.Take);
        }

        return query;
    }
}