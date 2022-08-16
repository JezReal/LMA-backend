using AutoMapper;
using LMA_backend.Books.Dtos;
using LMA_backend.Models;

namespace LMA_backend.Profiles;

public class BooksProfile : Profile
{
    public BooksProfile()
    {
        CreateMap<Book, GetBookWithIdDto>()
            .ForMember(destinationMember =>
                destinationMember.Author,
                options => options.MapFrom(sourceMember => $"{sourceMember.AuthorLastName}, {sourceMember.AuthorFirstName}")
            )
            .ForMember(destinationMember =>
                destinationMember.BookTitle,
                options => options.MapFrom(sourceMember => sourceMember.Title)
            );

        CreateMap<Book, GetBookDto>()
            .ForMember(destinationMember =>
                destinationMember.Author,
                options => options.MapFrom(sourceMember => $"{sourceMember.AuthorLastName}, {sourceMember.AuthorFirstName}")  
            );

        CreateMap<AddBookDto, Book>();
        CreateMap<UpdateBookDto, Book>();
    }
}