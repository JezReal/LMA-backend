using LMA_backend.Models;

namespace LMA_backend.Auth.Repositories;

public class AuthRepository : IAuthRepository
{
    public Task<Credential?> GetCredentialByEmailAddress(string emailAddress)
    {
        throw new NotImplementedException();
    }

    public Task<Credential> Registeruser(Credential credential)
    {
        throw new NotImplementedException();
    }

    public bool SaveChanges()
    {
        throw new NotImplementedException();
    }
}