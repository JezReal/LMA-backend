using AutoMapper;
using LMA_backend.Data;
using LMA_backend.Dtos;
using LMA_backend.Models;
using LMA_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace LMA_backend.Controllers
{
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
            return Ok(_mapper.Map<IEnumerable<GetBookDto>>(books));
        }

        [HttpGet("{bookId}", Name = "GetBookById")]
        public async Task<ActionResult<GetBookDto>> GetBookById(long bookId)
        {
            var book = await _bookService.GetBookById(bookId);

            if (book == null)
            {
                return NotFound();
            }

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
        public ActionResult UpdateBook()
        {
            return Problem(statusCode: 503, detail: "Not implemented yet");
        }

        [HttpDelete("{bookId}")]
        public ActionResult DeleteBook()
        {
            return Problem(statusCode: 503, detail: "Not implemented yet");
        }
    }
}