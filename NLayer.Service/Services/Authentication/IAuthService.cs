using NLayer.Core.DTO;
using NLayer.Core.Models;

namespace NLayer.Service.Services.Authentication
{
    public interface IAuthService<T>
    {
        
        Task<User> Register(UserAuthDto registerDto);
        Task<UserDto> Login(UserAuthDto loginDto);


    }
}
