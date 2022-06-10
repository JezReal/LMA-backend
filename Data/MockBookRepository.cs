using LMA_backend.Models;

namespace LMA_backend.Data;

public class MockBookRepository : IBookRepository
{
    public bool SaveChanges()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Book> GetBooks()
    {
        return new List<Book>
        {
            new Book {BookId = 1, Title = "Title one", AuthorFirstName = "Jezreel", AuthorLastName = "Martin"},
            new Book {BookId = 2, Title = "Title two", AuthorFirstName = "Jezreel", AuthorLastName = "Martin"},
            new Book {BookId = 3, Title = "Title three", AuthorFirstName = "Jezreel", AuthorLastName = "Martin"}
        };
    }

    public Book GetBookById(int id)
    {
        return new Book
        {
            BookId = 1, Title = "Title one", AuthorFirstName = "Jezreel", AuthorLastName = "Martin"
        };
    }

    public void AddBook(Book book)
    {
        throw new NotImplementedException();
    }

    public void UpdateBook(Book book)
    {
        throw new NotImplementedException();
    }

    public void DeleteBook(Book book)
    {
        throw new NotImplementedException();
    }
}