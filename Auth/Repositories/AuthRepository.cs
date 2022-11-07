using LMA_backend.Data;
using LMA_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace LMA_backend.Auth.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly LmaContext _lmaContext;

    public AuthRepository(LmaContext lmaContext)
    {
        _lmaContext = lmaContext;
    }

    public async Task<Credential?> GetCredentialByEmailAddress(string emailAddress)
    {
        return await _lmaContext.Credentials.FirstOrDefaultAsync(credential => credential.EmailAddress == emailAddress);
    }

    public async Task<Credential> RegisterUser(Credential credential)
    {
        if (credential == null)
        {
            throw new ArgumentNullException(nameof(credential));
        }

        _lmaContext.Credentials.Add(credential);
        await _lmaContext.SaveChangesAsync();

        return credential;
    }

    public bool SaveChanges()
    {
        return _lmaContext.SaveChanges() >= 0;
    }
}