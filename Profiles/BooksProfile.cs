using AutoMapper;
using LMA_backend.Dtos;
using LMA_backend.Models;

namespace LMA_backend.Profiles;

public class BooksProfile : Profile
{
    public BooksProfile()
    {
        CreateMap<Book, BookWithIdDto>();
        CreateMap<Book, BookDto>();
        CreateMap<AddBookDto, Book>();
    }
}