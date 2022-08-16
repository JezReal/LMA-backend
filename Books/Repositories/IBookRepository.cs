using LMA_backend.Models;

namespace LMA_backend.Books.Repositories;

public interface IBookRepository
{
    bool SaveChanges();

    Task<IEnumerable<Book>> GetBooks();
    Task<Book?> GetBookById(long id);
    Task AddBook(Book book);
    Task UpdateBook(long id, Book book);
    Task DeleteBook(Book book);
}