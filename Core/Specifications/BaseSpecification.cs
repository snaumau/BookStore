using System.Linq.Expressions;

namespace Core.Specifications;

/// <summary>
/// Base specifications
/// </summary>
/// <typeparam name="T"></typeparam>
public class BaseSpecification<T> : ISpecification<T>
{
    /// <summary>
    /// Default constructor
    /// </summary>
    protected BaseSpecification()
    {
    }
    
    /// <summary>
    /// Constructor with apply custom criteria
    /// </summary>
    /// <param name="criteria"></param>
    protected BaseSpecification(Expression<Func<T, bool>> criteria)
    {
        Criteria = criteria;
    }

    public Expression<Func<T, bool>>? Criteria { get; }

    public Expression<Func<T, object>>? OrderBy { get; private set; }
    
    public Expression<Func<T, object>>? OrderByDescending { get; private set; }
    
    public Expression<Func<T, bool>>? FilteredByDate { get; private set; }

    public List<Expression<Func<T, object>>> Includes { get; } = new();

    protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
    {
        OrderBy = orderByExpression;
    }
    
    protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
    {
        OrderByDescending = orderByDescExpression;
    }
    
    protected void AddFindByReleaseDate(Expression<Func<T, bool>> dateExpression)
    {
        FilteredByDate = dateExpression;
    }
    
    protected void AddInclude(Expression<Func<T, object>> includeExpression)
    {
        Includes.Add(includeExpression);
    }
}