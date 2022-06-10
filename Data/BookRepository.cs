using LMA_backend.Models;

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

    public IEnumerable<Book> GetBooks()
    {
        return _lmaContext.Books.ToList();
    }

    public Book? GetBookById(int id)
    {
        return _lmaContext.Books.FirstOrDefault(book => book.BookId == id);
    }

    public void AddBook(Book book)
    {
        if (book == null)
        {
            throw new ArgumentNullException(nameof(book));
        }

        _lmaContext.Books.Add(book);
    }

    public void UpdateBook(Book book)
    {
        throw new NotImplementedException();
    }

    public void DeleteBook(Book book)
    {
        if (book == null)
        {
            throw new ArgumentNullException(nameof(book));
        }

        _lmaContext.Books.Remove(book);
    }
}