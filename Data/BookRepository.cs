using LMA_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace LMA_backend.Data;

public class BookRepository : IBookRepository
{
    private readonly LmaContext _lmaContext;

    public BookRepository(LmaContext lmaContext)
    {
        _lmaContext = lmaContext;
    }

    public bool SaveChanges()
    {
        return _lmaContext.SaveChanges() >= 0;
    }

    public async Task<IEnumerable<Book>> GetBooks()
    {
        return await _lmaContext.Books.ToListAsync();
    }

    public async Task<Book?> GetBookById(int id)
    {
        return await _lmaContext.Books.FirstOrDefaultAsync(book => book.BookId == id);
    }

    public async Task AddBook(Book book)
    {
        Console.WriteLine($"Title: {book.Title}");
        Console.WriteLine($"Author: {book.AuthorLastName}, {book.AuthorFirstName}");
        if (book == null)
        {
            throw new ArgumentNullException(nameof(book));
        }

        _lmaContext.Books.Add(book);
        await _lmaContext.SaveChangesAsync(); 
    }

    public Task UpdateBook(Book book)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteBook(Book book)
    {
        if (book == null)
        {
            throw new ArgumentNullException(nameof(book));
        }

        _lmaContext.Books.Remove(book);
        await _lmaContext.SaveChangesAsync();
    }
}