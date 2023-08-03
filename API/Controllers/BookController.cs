using API.DTO;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("books")]
public class BookController : ControllerBase
{
    private readonly IGenericRepository<Book> _bookRepository;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="bookRepository"></param>
    public BookController(IGenericRepository<Book> bookRepository)
    {
        _bookRepository = bookRepository;
    }
    
    /// <summary>
    /// Get book by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Return the book</returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<BookDto>> GetBook(int id)
    {
        var book = await _bookRepository.GetByIdAsync(id);
        if (book is null)
            return BadRequest("Book didn't find");

        return new BookDto
        {
            Id = book.Id,
            Name = book.Name,
            Price = book.Price,
            ReleaseDate = book.ReleaseDate
        };
    }
    
    /// <summary>
    /// Get list of the books
    /// </summary>
    /// <returns>List of the books</returns>
    [HttpGet]
    public async Task<ActionResult<List<BookDto>>> GetBooks()
    {
        var books = await _bookRepository.ListAllAsync();
        if (!books.Any())
            return BadRequest("Books don't exist");

        var data = books.Select(book => new BookDto
        {
            Id = book.Id,
            Name = book.Name,
            Price = book.Price,
            ReleaseDate = book.ReleaseDate
        }).ToList();

        return data;
    }
}