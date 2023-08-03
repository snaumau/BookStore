using Core.Entities;

namespace Core.Interfaces;

public interface IBookRepository
{
    Task<Book?> GetProductByIdAsync(int? id);

    Task<IReadOnlyList<Book>> GetBooksAsync();
}