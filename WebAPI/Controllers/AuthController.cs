using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTO;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IService<User> _service;
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            var userSave = await _service.AddAsync(_mapper.Map<User>(request));
            var usersDto = _mapper.Map<UserDto>(userSave);
            return Ok(usersDto);
            
        }
    }
}
