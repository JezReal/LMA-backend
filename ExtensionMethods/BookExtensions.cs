using LMA_backend.Dtos;
using LMA_backend.Models;

namespace LMA_backend.ExtensionMethods;

public static class BookExtensions
{
    public static IEnumerable<BookWithIdDto> ToBookWithIdDto(this IEnumerable<Book> book)
    {
        return book.Select(item => new BookWithIdDto
        {
            BookId = item.BookId,
            BookTitle = item.Title,
            Author = $"{item.AuthorLastName}, {item.AuthorFirstName}"
        });
    }

    public static BookDto ToBookDto(this Book book)
    {
        return new BookDto
        {
            Title = book.Title,
            Author = $"{book.AuthorLastName}, {book.AuthorFirstName}"
        };
    }
}