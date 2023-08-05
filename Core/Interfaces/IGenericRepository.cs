using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces;

/// <summary>
/// Interface for generic repository
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(int? id);

    Task<IReadOnlyList<T>> ListAllAsync(ISpecification<T> spec);

    void Add(T entity);
    
    Task<T?> GetEntityWithSpec(ISpecification<T> spec);
}