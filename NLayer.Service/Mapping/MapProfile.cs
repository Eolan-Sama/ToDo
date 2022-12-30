using AutoMapper;
using NLayer.Core.DTO;
using NLayer.Core.Models;

namespace NLayer.Service.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserAuthDto>();
            CreateMap<Todo, TodoDto>().ReverseMap();
        }
        
    }
}
