using LMA_backend.Data;
using LMA_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace LMA_backend.Books.Repositories;

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

    public async Task<Book?> GetBookById(long id)
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

    public async Task UpdateBook(long bookId, Book book)
    {
        var bookModel = await _lmaContext.Books.FirstAsync(book => book.BookId == bookId);

        bookModel.Title = book.Title;
        bookModel.AuthorFirstName = book.AuthorFirstName;
        bookModel.AuthorLastName = book.AuthorLastName;

        _lmaContext.Books.Update(bookModel);
        await _lmaContext.SaveChangesAsync();
    }

    public async Task DeleteBook(Book book)
    {
        _lmaContext.Books.Remove(book);
        await _lmaContext.SaveChangesAsync();
    }
}