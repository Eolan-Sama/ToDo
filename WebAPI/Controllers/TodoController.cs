using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTO;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Todo> _service;


        public TodoController(IService<Todo> service,IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var response = await _service.GetAllAsync();
            var todoDto = _mapper.Map<List<TodoDto>>(response.ToList());
            return CreateActionResult<List<TodoDto>>(CustomResponseDto<List<TodoDto>>.Success(200, todoDto));
        }


        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var todo = await _service.GetByIdAsync(id);
            var todoDto = _mapper.Map<TodoDto>(todo);
            return Ok(todoDto);
        }

         [HttpGet("{UserId}/{status}")]

         public async Task<IActionResult> Where(string status,int UserId)
         {
             var todo = _service.Where(x => x.Status == status && x.UserId == UserId);
             var todosDto = _mapper.Map<List<TodoDto>>(todo.ToList());
             return Ok(todosDto);
         }
         [HttpGet("profile/{userId}")]

         public async Task<IActionResult> Where(int userId)
         {
             var todo = _service.Where(x => x.UserId == userId);
             var todoDto = _mapper.Map<List<TodoDto>>(todo.ToList());
             return Ok(todoDto);
         }
        [HttpPost]

        public async Task<IActionResult> Save(TodoDto todoDto)
        {
            var todo = await _service.AddAsync(_mapper.Map<Todo>(todoDto));
            var newTodoDto = _mapper.Map<TodoDto>(todo);
            return Ok(newTodoDto);
        }
        [HttpPut]

        public async Task<IActionResult> Update(TodoDto todoDto)
        {
            await _service.UpdateAsync(_mapper.Map<Todo>(todoDto));
            return Ok(todoDto);
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> Remove(int id)
        {
            var todo = await _service.GetByIdAsync(id);
            todo.IsDeleted=true;
            await _service.RemoveAsync(_mapper.Map<Todo>(todo));
            return Ok(204);
        }
    }

}
