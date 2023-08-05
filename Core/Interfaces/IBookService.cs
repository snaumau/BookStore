using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces;

public interface IBookService
{
    Task<Book?> GetBookByIdAsync(int? id);

    Task<IReadOnlyList<Book>?> GetBooksAsync(BookSpecificationParams bookParams);

    Task<Book?> CreateBookAsync(Book book);

    Task<bool> DeleteAsync(int id);
}