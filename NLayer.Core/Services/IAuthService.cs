using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Services
{
    public interface IAuthService<T> where T : class
    {
        Task<T> Register(T registerInDto);
        Task<T> Login(T loginInDto);
        Task<T> RefreshToken(string refreshToken);
        Task RevokeToken(string revokeToken);
        Task<bool> ForgotPasswordInitiate(string eMail);
        Task<bool> ForgotPasswordChange(T forgotInDto);
    }
}
