using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayer.Core.DTO;

namespace NLayer.Service.Services.Authentication.JWT
{
    public interface IJwtTokenGenerator
    {
        TokenModel GenerateToken(UserDto entity);

    }
}
