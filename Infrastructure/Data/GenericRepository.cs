using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

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

    public async Task<IReadOnlyList<T>> ListAllAsync()
    {
        return await _storeContext.Set<T>().ToListAsync();
    }
}