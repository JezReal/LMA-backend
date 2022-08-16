using LMA_backend.Auth.Dtos;
using LMA_backend.Models;

namespace LMA_backend.Services.Auth;

public interface IAuthService
{
    Task<Credential?> GetCredentialByEmailAddress(string emailAddress);
    Task<Credential> Registeruser(RegisterDto registerDto);
}