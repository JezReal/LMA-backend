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

    public async Task<IEnumerable<BookDto>> GetBooks()
    {
        var books = await _bookRepository.GetBooks();

        return _mapper.Map<IEnumerable<BookDto>>(books);
    }

    public async Task<GetBookDto?> GetBookById(int bookId)
    {
        var book = await _bookRepository.GetBookById(bookId);

        if (book == null)
        {
            return null;
        }

        return _mapper.Map<GetBookDto>(book);
    }

    public async Task<BookDto> AddBook(Book book)
    {
        var bookRequest = _mapper.Map<Book>(book);

        await _bookRepository.AddBook(bookRequest);

        return _mapper.Map<BookDto>(bookRequest);
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