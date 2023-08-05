using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

/// <summary>
/// Generic repository for entities
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

    public void Add(T entity)
    {
        _storeContext.Set<T>().Add(entity);
    }

    public void Update(T entity)
    {
        _storeContext.Set<T>().Attach(entity);
        _storeContext.Entry(entity).State = EntityState.Modified;
    }

    public async Task<T?> GetEntityWithSpec(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).FirstOrDefaultAsync();
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _storeContext.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
        if (entity == null)
            return false;
        
        _storeContext.Remove(entity);
        await _storeContext.SaveChangesAsync();

        return true;
    }

    private IQueryable<T> ApplySpecification(ISpecification<T> spec)
    {
        var query = _storeContext.Set<T>().AsQueryable();

        return SpecificationEvaluator<T>.GetQuery(query, spec);
    }
}