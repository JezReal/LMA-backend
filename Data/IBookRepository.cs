using LMA_backend.Models;

namespace LMA_backend.Data;

public interface IBookRepository
{
    bool SaveChanges();

    IEnumerable<Book> GetBooks();
    Book? GetBookById(int id);
    void AddBook(Book book);
    void UpdateBook(Book book);
    void DeleteBook(Book book);
}