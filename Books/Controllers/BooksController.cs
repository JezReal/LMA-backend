using AutoMapper;
using LMA_backend.Books.Dtos;
using LMA_backend.Books.Services;
using LMA_backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace LMA_backend.Books.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;
    private readonly IMapper _mapper;

    public BooksController(IBookService bookService, IMapper mapper)
    {
        _bookService = bookService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetBookWithIdDto>>> GetBooks()
    {
        var books = await _bookService.GetBooks();
        return Ok(_mapper.Map<IEnumerable<GetBookWithIdDto>>(books));
    }

    [HttpGet("{bookId}", Name = "GetBookById")]
    public async Task<ActionResult<GetBookDto>> GetBookById(long bookId)
    {
        var book = await _bookService.GetBookById(bookId);

        return Ok(_mapper.Map<GetBookDto>(book));
    }

    [HttpPost]
    public async Task<ActionResult<GetBookWithIdDto>> AddBook(AddBookDto addBookDto)
    {
        var bookRequest = await _bookService.AddBook(addBookDto);
        var bookDto = _mapper.Map<Book>(bookRequest);

        return CreatedAtRoute(nameof(GetBookById), new { bookId = bookDto.BookId }, bookDto);
    }

    [HttpPut("{bookId}")]
    public async Task<ActionResult> UpdateBook(long bookId, UpdateBookDto updateBookDto)
    {
        await _bookService.UpdateBook(bookId, updateBookDto);

        return Ok();
    }

    [HttpDelete("{bookId}")]
    public async Task<ActionResult> DeleteBook(long bookId)
    {
        await _bookService.DeleteBook(bookId);

        return Ok();
    }
}
