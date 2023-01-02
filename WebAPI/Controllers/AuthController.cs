using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly IService<Todo> _todoService;
        public AuthController(IService<User> service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            var userSave = await _service.AddAsync(_mapper.Map<User>(request));
            var usersDto = _mapper.Map<UserDto>(userSave);
            return Ok(usersDto);
            
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var response = await _service.GetAllAsync();
            var userDto = _mapper.Map<List<UserDto>>(response.ToList());

            return Ok(userDto);
    }

        [HttpPost("login")]
        public async Task<IActionResult> LoginTask(string email, string pass)
        {
            var response = await _service.AnyAsync(x => x.Email == email && x.Password == pass);
            //var userDto = _mapper.Map<UserDto>(response);
            if (response == false)
            {
                return Ok("Email yada Sifre Hatali");
            }

            if (response == true)
            {
                var LoggedInUser =   _service.Where(x => x.Email == email && x.Password == pass).FirstOrDefault();
                var CurrentUser = _mapper.Map<UserAuthDto>(LoggedInUser);
                var CurrentUsersTodo = _todoService.Where(x => x.UserId == CurrentUser.Id);
                //var CurrentUsersTodoDto = _mapper.Map<List<TodoDto>>(CurrentUsersTodo.ToList());
                return Ok(CurrentUsersTodo);
            }
            return Ok(true);
        }
    }
    
}
