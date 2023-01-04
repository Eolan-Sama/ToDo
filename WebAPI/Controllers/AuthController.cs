using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTO;
using NLayer.Core.Models;
using NLayer.Core.Services;
using NLayer.Service.Services.Authentication;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService<User> _authService;
        public AuthController(IAuthService<User> authService)
        {
            _authService = authService;
            
            
        }
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserAuthDto request)
        {
            var RegisterUser = _authService.Register(request);
            return Ok(RegisterUser);
            
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginTask(UserAuthDto request)
        {
            var LoginUser = _authService.Login(request);
            
            return Ok(LoginUser);
        }
    }
    
}
