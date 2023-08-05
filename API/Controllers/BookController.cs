using API.DTO;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

/// <summary>
/// Book controller
/// </summary>
public class BookController : BaseApiController
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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BookDto>> GetBook(int id)
    {
        var book = await _bookRepository.GetByIdAsync(id);
        if (book is null)
            return NotFound(new ApiResponse(404));

        return _mapper.Map<BookDto>(book);
    }
    
    /// <summary>
    /// Get list of the books
    /// </summary>
    /// <returns>Return the list of the books</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IReadOnlyList<BookDto>>> GetBooks([FromQuery] BookSpecificationParams bookParams)
    {
        var specification = new BooksSpecification(bookParams);
        var books = await _bookRepository.ListAllAsync(specification);

        var data = _mapper.Map<IReadOnlyList<BookDto>>(books);

        return Ok(data);
    }
}