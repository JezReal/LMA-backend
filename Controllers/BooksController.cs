using AutoMapper;
using LMA_backend.Data;
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
            return Ok(_bookRepository.GetBooks());
        }
        
        [HttpGet("{bookId}", Name = "Get book by id")]
        public ActionResult<Book> GetBookById()
        {
            return Problem(statusCode: 503, detail: "Not implemented yet");
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