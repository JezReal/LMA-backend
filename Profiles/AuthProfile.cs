using AutoMapper;
using LMA_backend.Auth.Dtos;
using LMA_backend.Models;

namespace LMA_backend.Profiles;

public class AuthProfile : Profile
{
    public AuthProfile()
    {
        CreateMap<RegisterDto, Credential>();
        CreateMap<Credential, AccountCreatedDto>();
    }
}