using LMA_backend.Auth.Dtos;
using LMA_backend.Models;
using LMA_backend.Services.Auth;

namespace LMA_backend.Auth.Services;

public class AuthService : IAuthService
{
    public Task<Credential?> GetCredentialByEmailAddress(string emailAddress)
    {
        throw new NotImplementedException();
    }

    public Task<Credential> Registeruser(RegisterDto registerDto)
    {
        throw new NotImplementedException();
    }
}