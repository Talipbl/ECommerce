using ECommerceNetCore.Application.Aspects;
using ECommerceNetCore.Application.DataTransferObjects;
using ECommerceNetCore.Application.Helpers;
using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Application.Results;
using ECommerceNetCore.Domain.Common;
using ECommerceNetCore.Domain.Entities;

namespace ECommerceNetCore.Application.Services
{
    public class AuthService : IAuthService
    {
        public IUserService _userService;

        public AuthService(IUserService userService)
        {
            _userService = userService;
        }
        [SecurityOperationAspect(Level:(int)UserLevels.VeryLow)]
        public IDataResult<LoginDto> Login(LoginDto loginUser)
        {
            var result = _userService.GetUser(loginUser.UserName, loginUser.Mail);
            if (!result.Success)
            {
                return new ErrorDataResult<LoginDto>(loginUser, UserConsts.UserNotFound);
            }

            var isAuth = HashigHelper.VerifyPasswordHash(loginUser.Password, result.Data.PasswordHash, result.Data.PasswordSalt);
            if (isAuth)
            {
                return new SuccessDataResult<LoginDto>(loginUser, UserConsts.LoginSuccesful);
            }

            return new ErrorDataResult<LoginDto>(loginUser, UserConsts.PasswordIncorrect);
        }

        public IDataResult<RegisterDto> Register(RegisterDto registerUser)
        {
            byte[] passwordHash, passwordSalt;

            var result = _userService.GetUser(registerUser.UserName, registerUser.Mail);
            if (result.Success)
            {
                return new ErrorDataResult<RegisterDto>(registerUser, UserConsts.UserAlreadyExist);
            }

            HashigHelper.CreatePasswordHash(registerUser.Password, out passwordHash, out passwordSalt);

            var newUser = CreateUser(registerUser, passwordHash, passwordSalt);
            if (!newUser.Success)
            {
                return new ErrorDataResult<RegisterDto>(registerUser, UserConsts.UserDoesNotSave);
            }

            return new SuccessDataResult<RegisterDto>(registerUser, UserConsts.UserSuccessfullyCreated);
        }

        private IDataResult<GnlUser> CreateUser(RegisterDto registerUser, byte[] passwordHash, byte[] passwordSalt)
        {
            GnlUser user = new GnlUser()
            {
                FirstName = registerUser.FirstName,
                LastName = registerUser.LastName,
                MailAddress = registerUser.Mail,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CreatedDate = DateTime.Now,
                StatusId = (int)StatusTypes.Active,
            };

            return _userService.AddUser(user);
        }
    }
}
