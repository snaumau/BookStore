using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

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

        query = spec.Includes!.Aggregate(query, (current, include) => current.Include(include));

        return query;
    }
}