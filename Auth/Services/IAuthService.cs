using LMA_backend.Auth.Dtos;
using LMA_backend.Models;

namespace LMA_backend.Auth.Services;

public interface IAuthService
{
    Task<RegisterDto?> GetCredentialByEmailAddress(string emailAddress);
    Task<Credential> RegisterUser(RegisterDto registerDto);
    Task<String> Login(LoginDto loginDto);
}