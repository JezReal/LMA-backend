using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using LMA_backend.Auth.Dtos;
using LMA_backend.Auth.Repositories;
using LMA_backend.Exceptions;
using LMA_backend.Models;
using Microsoft.IdentityModel.Tokens;

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
        var account = await _authRepository.GetCredentialByEmailAddress(registerDto.EmailAddress);

        if (account != null)
        {
            throw new BadRequestException("Account already exists");
        }

        registerDto.Password = HashPassword(registerDto.Password);

        var credential = _mapper.Map<Credential>(registerDto);

        return await _authRepository.RegisterUser(credential);
    }

    public async Task<String> Login(LoginDto loginDto)
    {
        var account = await _authRepository.GetCredentialByEmailAddress(loginDto.EmailAddress);

        if (account == null)
        {
            throw new ResourceNotFoundException("Account not found");
        }

        var hashedPassword = account.Password;

        if (Bcrypt.Verify(loginDto.Password, hashedPassword))
        {
            return CreateAccessToken(account.EmailAddress);
        }
        else
        {
            throw new AuthenticationException("Invalid credentials");
        }
    }

    private string HashPassword(string password)
    {
        return Bcrypt.HashPassword(password);
    }

    private string CreateAccessToken(string emailAddress)
    {
        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Variables:SigningKey").Value));
        var claims = new List<Claim> {
            new Claim (ClaimTypes.Email, emailAddress)
        };

        var token = new JwtSecurityToken(
            issuer: _configuration.GetSection("Variables:Issuer").Value,
            audience: _configuration.GetSection("Variables:Audience").Value,
            expires: DateTime.Now.AddMinutes(5),
            claims: claims,
            signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
        );

        var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);

        return encodedToken;
    }
}