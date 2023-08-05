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
    private readonly IBookService _bookService;
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="bookService"></param>
    /// <param name="mapper"></param>
    public BookController(IBookService bookService, IMapper mapper)
    {
        _bookService = bookService;
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
        var book = await _bookService.GetBookByIdAsync(id);
        if (book is null)
            return NotFound(new ApiResponse(404));

        return _mapper.Map<BookDto>(book);
    }
    
    /// <summary>
    /// Get list of the books
    /// </summary>
    /// <returns>Return the list of the books</returns>
    [HttpGet("getFilteredBooks")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IReadOnlyList<BookDto>>> GetBooks([FromQuery] BookSpecificationParams bookParams)
    {
        var books = await _bookService.GetBooksAsync(bookParams);
        
        // SqLite doesn't support ToLower() in the query
        // If use another database provider - disable this
        if (!string.IsNullOrWhiteSpace(bookParams.Search))
            books = books?.Where(x => x.Name.ToLower().Contains(bookParams.Search))
                .ToList();
        
        var data = _mapper.Map<IReadOnlyList<BookDto>>(books);

        return Ok(data);
    }
    
    /// <summary>
    /// Create book
    /// </summary>
    /// <param name="bookDto"></param>
    /// <returns>Return created book</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BookDto>> CreateBook(BookDto bookDto)
    {
        var book = _mapper.Map<Book>(bookDto);
        var entity = await _bookService.CreateBookAsync(book);
        if (entity is null)
            return BadRequest(new ApiResponse(400));

        var data = _mapper.Map<BookDto>(entity);

        return Ok(data);
    }
    
    /// <summary>
    /// Delete book
    /// </summary>
    /// <param name="bookId"></param>
    /// <returns>Return true</returns>
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<bool>> DeleteBook(int bookId)
    {
        var result = await _bookService.DeleteAsync(bookId);
        if (!result)
            return BadRequest(new ApiResponse(400));

        return Ok(true);
    }
}