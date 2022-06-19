using Lma_backend.Dtos;
using LMA_backend.Dtos;
using LMA_backend.Models;

namespace LMA_backend.Services;

public interface IBookService
{
    Task<IEnumerable<Book>> GetBooks();
    Task<Book?> GetBookById(long bookId);
    Task<Book> AddBook(AddBookDto addBookDto);
    Task UpdateBook(long bookId, UpdateBookDto bookRequest);
    Task DeleteBook(Book bookRequest);
}