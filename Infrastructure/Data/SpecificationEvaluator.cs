using Core.Entities;
using Core.Specifications;

namespace Infrastructure.Data;

/// <summary>
/// Specification evaluator for query
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public abstract class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
{
    public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> query, ISpecification<TEntity> spec)
    {
        if (spec.Criteria != null)
            query = query.Where(spec.Criteria);
        
        if (spec.OrderBy != null)
            query = query.OrderBy(spec.OrderBy);

        if (spec.OrderByDescending != null)
            query = query.OrderByDescending(spec.OrderByDescending);
        
        if (spec.FilteredByDate != null)
            query = query.Where(spec.FilteredByDate);

        return query;
    }
}