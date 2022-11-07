using System.Security.Claims;
using System.Security.Cryptography;
using AutoMapper;
using JWT.Algorithms;
using JWT.Builder;
using LMA_backend.Auth.Dtos;
using LMA_backend.Auth.Repositories;
using LMA_backend.Exceptions;
using LMA_backend.Models;

namespace LMA_backend.Auth.Services;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepository;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public AuthService(IAuthRepository authRepository, IMapper mapper, IConfiguration configuration)
    {
        _authRepository = authRepository;
        _mapper = mapper;
        _configuration = configuration;
    }

    public Task<RegisterDto?> GetCredentialByEmailAddress(string emailAddress)
    {
        throw new NotImplementedException();
    }

    public async Task<Credential> RegisterUser(RegisterDto registerDto)
    {
        var account = _authRepository.GetCredentialByEmailAddress(registerDto.EmailAddress)?.Result;

        if (account != null)
        {
            throw new BadRequestException("Account already exists");
        }

        registerDto.Password = HashPassword(registerDto.Password);

        var credential = _mapper.Map<Credential>(registerDto);

        return await _authRepository.RegisterUser(credential);
    }

    public Task Login(LoginDto loginDto)
    {
        var account = _authRepository.GetCredentialByEmailAddress(loginDto.EmailAddress)?.Result;

        if (account == null)
        {
            throw new ResourceNotFoundException("Account not found");
        }

        var hashedPassword = account.Password;

        if (BCrypt.Net.BCrypt.Verify(loginDto.Password, hashedPassword))
        {
            CreateAccessToken();
        }
        else
        {
            throw new AuthenticationException("Invalid credentials");
        }

        return Task.CompletedTask;
    }

    private string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    private void CreateAccessToken()
    {
        var privateKeyString = _configuration.GetSection("Variables:PrivateKey").Value;
        var privateKey = Convert.FromBase64String(privateKeyString);

        var publicKeyString = _configuration.GetSection("Variables:PublicKey").Value;
        var publicKey = Convert.FromBase64String(publicKeyString);

        using RSA rsaPrivateKey = RSA.Create();
        rsaPrivateKey.ImportRSAPrivateKey(privateKey, out _);

        using RSA rsaPublicKey = RSA.Create();
        rsaPublicKey.ImportRSAPublicKey(publicKey, out _);

        var token = JwtBuilder.Create()
                        .WithAlgorithm(new RS512Algorithm(rsaPublicKey, rsaPrivateKey))
                        .AddClaim("exp", DateTime.Now.AddMinutes(5))
                        .AddClaim("helli", "hello")
                        .Encode();

        Console.WriteLine(token);
    }
}