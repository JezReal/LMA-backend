using LMA_backend.Dtos;
using LMA_backend.Models;

namespace LMA_backend.Services;

public interface IBookService
{
    Task<IEnumerable<BookDto>> GetBooks();
    Task<GetBookDto?> GetBookById(int bookId);
    Task<BookDto> AddBook(Book bookRequest);
    Task UpdateBook(Book bookRequest);
    Task DeleteBook(Book bookRequest);
}