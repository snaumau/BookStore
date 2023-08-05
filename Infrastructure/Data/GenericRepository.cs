using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

/// <summary>
/// Repository for entities
/// </summary>
/// <typeparam name="T"></typeparam>
public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly StoreContext _storeContext;

    public GenericRepository(StoreContext storeContext)
    {
        _storeContext = storeContext;
    }
    
    public async Task<T?> GetByIdAsync(int? id)
    {
        return id is null or 0 ? null : await _storeContext.Set<T>().FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> ListAllAsync(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).ToListAsync();
    }
    
    private IQueryable<T> ApplySpecification(ISpecification<T> spec)
    {
        var query = _storeContext.Set<T>().AsQueryable();

        return SpecificationEvaluator<T>.GetQuery(query, spec);
    }
}