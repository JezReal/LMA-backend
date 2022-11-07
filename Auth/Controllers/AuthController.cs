using AutoMapper;
using LMA_backend.Auth.Dtos;
using LMA_backend.Auth.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMA_backend.Auth.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IAuthService _authService;

    public AuthController(IMapper mapper, IAuthService authService)
    {
        _mapper = mapper;
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<AccountCreatedDto>> Register(RegisterDto registerDto)
    {
        return _mapper.Map<AccountCreatedDto>(await _authService.RegisterUser(registerDto));
    }

    [HttpPost("login"), AllowAnonymous]
    public async Task<ActionResult> Login(LoginDto loginDto)
    {
        await _authService.Login(loginDto);
        return Ok();
    }
}