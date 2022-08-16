using AutoMapper;
using LMA_backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMA_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMapper _mapper;

        public AuthController(IMapper mapper)
        {
            _mapper = mapper;
        }


        [HttpPost, AllowAnonymous]
        public async Task<ActionResult> Register()
        {

            return Ok();
        }

        [HttpPost, AllowAnonymous]
        public async Task<ActionResult> Login()
        {
            return Ok();
        }
    }
}
