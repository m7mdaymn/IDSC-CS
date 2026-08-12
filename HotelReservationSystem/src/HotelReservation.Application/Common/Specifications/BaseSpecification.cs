using System.Linq.Expressions;
using HotelReservation.Domain.Common;

namespace HotelReservation.Application.Common.Specifications;

public abstract class BaseSpecification<TEntity>
    : ISpecification<TEntity>
    where TEntity : BaseEntity
{
    protected BaseSpecification()
    {
    }

    protected BaseSpecification(
        Expression<Func<TEntity, bool>> criteria)
    {
        Criteria = criteria;
    }

    public Expression<Func<TEntity, bool>>? Criteria { get; }

    protected List<Expression<Func<TEntity, object>>> IncludeExpressions
        { get; } = [];

    public IReadOnlyList<Expression<Func<TEntity, object>>> Includes
        => IncludeExpressions;

    public Expression<Func<TEntity, object>>? OrderBy
        { get; private set; }

    public Expression<Func<TEntity, object>>? OrderByDescending
        { get; private set; }

    public int Skip { get; private set; }

    public int Take { get; private set; }

    public bool IsPagingEnabled { get; private set; }

    public bool AsNoTracking { get; private set; } = true;

    public bool IncludeSoftDeleted { get; private set; } = false;

    protected void AddInclude(
        Expression<Func<TEntity, object>> includeExpression)
    {
        IncludeExpressions.Add(includeExpression);
    }

    protected void ApplyOrderBy(
        Expression<Func<TEntity, object>> expression)
    {
        OrderBy = expression;
    }

    protected void ApplyOrderByDescending(
        Expression<Func<TEntity, object>> expression)
    {
        OrderByDescending = expression;
    }

    protected void ApplyPaging(
        int skip,
        int take)
    {
        Skip = skip;
        Take = take;
        IsPagingEnabled = true;
    }

    protected void EnableTracking()
    {
        AsNoTracking = false;
    }

    protected void IncludeSoftDeletedEntities()
    {
        IncludeSoftDeleted = true;
    }
}