using Core.Entities;
using Core.Interfaces;
using Core.Specifications;

namespace Infrastructure.Services;

/// <summary>
/// Book service
/// </summary>
public class BookService : IBookService
{
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="unitOfWork"></param>
    public BookService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Book?> GetBookByIdAsync(int? id)
    {
        return await _unitOfWork.Repository<Book>().GetByIdAsync(id);
    }

    public async Task<IReadOnlyList<Book>?> GetBooksAsync(BookSpecificationParams bookParams)
    {
        var specification = new BooksSpecification(bookParams);
        
        return await _unitOfWork.Repository<Book>().ListAllAsync(specification);
    }

    public async Task<Book?> CreateBookAsync(Book? book)
    {
        if (book == null)
            return null;
        
        _unitOfWork.Repository<Book>().Add(book);
        
        var result = await _unitOfWork.Complete();
        if (result <= 0)
            return null;

        return book;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        await _unitOfWork.Repository<Book>().DeleteAsync(id);

        var result = await _unitOfWork.Complete();
        if (result > 0)
            return false;

        return true;
    }
}