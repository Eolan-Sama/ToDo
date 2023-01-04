using AutoMapper;
using NLayer.Core.DTO;
using NLayer.Core.Models;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Service.Services.Authentication.JWT;

namespace NLayer.Service.Services.Authentication
{
    public class AuthService<T> : IAuthService<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IService<User> _service;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public AuthService(IUnitOfWork unitOfWork, IMapper mapper, IService<User> service, IJwtTokenGenerator jwtTokenGenerator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _service = service;
            _jwtTokenGenerator = jwtTokenGenerator;
        }


        public async Task<User> Register(UserAuthDto registerDto)
        {
            //Check user if exists
            var CheckUser = await _service.GetByMail(registerDto.Email);
            if (CheckUser != null)
            {
                throw new Exception("Bu email daha önce kullanılmış. Şifrenizi unutmuş olabilir misiniz?");
            }
            //If is not exist create a new user
            var userSave = await _service.AddAsync(_mapper.Map<User>(CheckUser));
            var NewUser = _mapper.Map<UserDto>(userSave);
            //Create a JWT for new account and update the account with its new JWT
            var jwt =_jwtTokenGenerator.GenerateToken(NewUser);
            var UpdatedUser = _mapper.Map<User>(NewUser);
            await _service.UpdateAsync(UpdatedUser);
            return UpdatedUser;

        }

        public async Task<UserDto> Login(UserAuthDto loginDto)
        {
            //Check user if its available
            var CheckUser = await _service.GetByMail(loginDto.Email);
            if (CheckUser == null)
            {
                throw new Exception("Hesap Bulunamadı");
            }
            if (CheckUser.Password != loginDto.Password)
            {
                throw new Exception("Şifreniz yanlış");
            }
            //Return User if available
            var userDto = _mapper.Map<UserDto>(CheckUser);
            return userDto;
        }
    }
}
