using LMA_backend.Models;

namespace LMA_backend.Data;

public interface IBookRepository
{
    bool SaveChanges();

    Task<IEnumerable<Book>> GetBooks();
    Task<Book?> GetBookById(long id);
    Task AddBook(Book book);
    Task UpdateBook(Book book);
    Task DeleteBook(Book book);
}