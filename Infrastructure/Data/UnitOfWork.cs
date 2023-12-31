using System.Collections;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data;

/// <summary>
/// Unit of work pattern for Generic repository 
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    private readonly StoreContext _storeContext;
    private Hashtable? _repositories;

    public UnitOfWork(StoreContext storeContext)
    {
        _storeContext = storeContext;
    }
    
    public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
    {
        _repositories ??= new Hashtable();

        var type = typeof(TEntity).Name;
        if (!_repositories.ContainsKey(type))
        {
            var repositoryType = typeof(GenericRepository<>);
            var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _storeContext);
            
            _repositories.Add(type, repositoryInstance);
        }

        return (IGenericRepository<TEntity>) _repositories[type]!;
    }

    public async Task<int> Complete()
    {
        return await _storeContext.SaveChangesAsync();
    }
    
    public void Dispose()
    {
        _storeContext.Dispose();
    }
}