using API.DTO;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("books")]
public class BookController : ControllerBase
{
    private readonly IGenericRepository<Book> _bookRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="bookRepository"></param>
    /// <param name="mapper"></param>
    public BookController(IGenericRepository<Book> bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
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

        return _mapper.Map<BookDto>(book);
    }
    
    /// <summary>
    /// Get list of the books
    /// </summary>
    /// <returns>List of the books</returns>
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<BookDto>>> GetBooks()
    {
        var books = await _bookRepository.ListAllAsync();
        if (!books.Any())
            return BadRequest("Books don't exist");

        var data = _mapper.Map<IReadOnlyList<BookDto>>(books);

        return Ok(data);
    }
}