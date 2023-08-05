using Core.Entities;

namespace Core.Interfaces;

/// <summary>
/// Service for unit of work pattern
/// </summary>
public interface IUnitOfWork : IDisposable
{
    IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;

    Task<int> Complete();
}