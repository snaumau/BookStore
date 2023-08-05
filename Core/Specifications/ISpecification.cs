using System.Linq.Expressions;

namespace Core.Specifications;

/// <summary>
/// Interface for specification
/// </summary>
/// <typeparam name="T"></typeparam>
public interface ISpecification<T>
{
    Expression<Func<T, bool>>? Criteria { get; }
    
    Expression<Func<T, object>>? OrderBy { get; }
    
    Expression<Func<T, object>>? OrderByDescending { get; }
    
    Expression<Func<T, bool>>? FilteredByDate { get; }
}