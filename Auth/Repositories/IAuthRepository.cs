using LMA_backend.Auth.Dtos;
using LMA_backend.Models;

namespace LMA_backend.Auth.Repositories;

public interface IAuthRepository
{
    bool SaveChanges();
    Task<Credential?> GetCredentialByEmailAddress(string emailAddress);
    Task<Credential> RegisterUser(Credential credential);
}