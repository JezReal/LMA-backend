using AutoMapper;
using LMA_backend.Data;
using LMA_backend.Dtos;
using LMA_backend.Models;
using LMA_backend.Services;

namespace LMA_Backend.Services;
public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public BookService(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Book>> GetBooks()
    {
        return await _bookRepository.GetBooks();
    }

    public async Task<Book?> GetBookById(long bookId)
    {
        var book = await _bookRepository.GetBookById(bookId);

        if (book == null)
        {
            return null;
        }

        return book;
    }

    public async Task<Book> AddBook(AddBookDto addBookDto)
    {
        var addBookRequest = _mapper.Map<Book>(addBookDto);

        await _bookRepository.AddBook(addBookRequest);

        return _mapper.Map<Book>(addBookRequest);
    }

    public Task UpdateBook(Book bookRequest)
    {
        throw new NotImplementedException();
    }

    public Task DeleteBook(Book bookRequest)
    {
        throw new NotImplementedException();
    }
}