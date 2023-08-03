using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class BookRepository : IBookRepository
{
    private readonly StoreContext _storeContext;
    
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="storeContext"></param>
    public BookRepository(StoreContext storeContext)
    {
        _storeContext = storeContext;
    }
    
    public async Task<Book?> GetProductByIdAsync(int? id)
    {
        return id is null or 0 ? null : await _storeContext.Books!.FindAsync(id);
    }

    public async Task<IReadOnlyList<Book>> GetBooksAsync()
    {
        return await _storeContext.Books!.ToListAsync();
    }
}