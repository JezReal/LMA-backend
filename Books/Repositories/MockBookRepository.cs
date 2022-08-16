using LMA_backend.Models;

namespace LMA_backend.Books.Repositories;

public class MockBookRepository : IBookRepository
{
    public bool SaveChanges()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Book>> GetBooks()
    {
        return await Task.Run(() =>
        {
            return new List<Book>
            {
                new Book {BookId = 1, Title = "Title one", AuthorFirstName = "Jezreel", AuthorLastName = "Martin"},
                new Book {BookId = 2, Title = "Title two", AuthorFirstName = "Jezreel", AuthorLastName = "Martin"},
                new Book {BookId = 3, Title = "Title three", AuthorFirstName = "Jezreel", AuthorLastName = "Martin"}
            };
        });
    }

    public async Task<Book?> GetBookById(long id)
    {
        return await Task.Run(() =>
        {
            return new Book
            {
                BookId = 1,
                Title = "Title one",
                AuthorFirstName = "Jezreel",
                AuthorLastName = "Martin"
            };
        });
    }

    public Task AddBook(Book book)
    {
        throw new NotImplementedException();
    }

    public Task UpdateBook(long bookId, Book book)
    {
        throw new NotImplementedException();
    }

    public Task DeleteBook(Book book)
    {
        throw new NotImplementedException();
    }
}