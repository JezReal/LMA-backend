using AutoMapper;
using LMA_backend.Data;
using LMA_backend.Dtos;
using LMA_backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace LMA_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BooksController(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            var books = await _bookRepository.GetBooks();
            return Ok(_mapper.Map<IEnumerable<BookWithIdDto>>(books));
        }

        [HttpGet("{bookId}", Name = "GetBookById")]
        public async Task<ActionResult<Book>> GetBookById(int bookId)
        {
            var book = await _bookRepository.GetBookById(bookId);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<GetBookDto>(book));
        }

        [HttpPost]
        public async Task<ActionResult<BookWithIdDto>> AddBook(AddBookDto addBookDto)
        {
            var bookRequest = _mapper.Map<Book>(addBookDto);

            await _bookRepository.AddBook(bookRequest);

            var bookDto = _mapper.Map<BookWithIdDto>(bookRequest);
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