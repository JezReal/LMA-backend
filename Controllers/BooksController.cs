using AutoMapper;
using LMA_backend.Data;
using LMA_backend.Dtos;
using LMA_backend.ExtensionMethods;
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
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            var books = _bookRepository.GetBooks().ToBookWithIdDto();
            return Ok(_mapper.Map<IEnumerable<BookWithIdDto>>(books));
        }

        [HttpGet("{bookId}", Name = "Get book by id")]
        public ActionResult<Book> GetBookById(int bookId)
        {
            var book = _bookRepository.GetBookById(bookId)?.ToBookDto();

            if (book == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<BookDto>(book));
        }

        [HttpPost]
        public ActionResult<Book> AddBook()
        {
            return Problem(statusCode: 503, detail: "Not implemented yet");
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