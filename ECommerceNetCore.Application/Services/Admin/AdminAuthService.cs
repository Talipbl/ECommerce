using ECommerce.Application.DataTransferObjects.Authentications;
using ECommerce.Application.Helpers;
using ECommerce.Application.Interfaces.Services.Admin;

namespace ECommerce.Admin
{
    public class AdminAuthService : IAuthService
    {
        IAdminService _adminService;

        public AdminAuthService(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public IDataResult<LoginDto> Login(LoginDto loginUser)
        {
            var result = _adminService.GetAdmin(loginUser.UserName);
            if (!result.Success)
            {
                return new ErrorDataResult<LoginDto>(loginUser, UserConsts.UserNotFound);
            }

            var isAuth = HashigHelper.VerifyPasswordHash(loginUser.Password, result.Data.PasswordHash, result.Data.PasswordSalt);
            if (isAuth)
            {
                return new SuccessDataResult<LoginDto>(loginUser, UserConsts.LoginSuccesful);
            }

            loginUser.SecurityLevel = result.Data.SecurityLevel;
            return new ErrorDataResult<LoginDto>(loginUser, UserConsts.PasswordIncorrect);
        }

        public IDataResult<RegisterDto> Register(RegisterDto registerUser)
        {
            byte[] passwordHash, passwordSalt;

            var result = _adminService.GetAdmin(registerUser.UserName);
            if (result.Success)
            {
                return new ErrorDataResult<RegisterDto>(registerUser, UserConsts.UserAlreadyExist);
            }

            HashigHelper.CreatePasswordHash(registerUser.Password, out passwordHash, out passwordSalt);

            var newAdmin = CreateAdmin(registerUser, passwordHash, passwordSalt);
            if (!newAdmin.Success)
            {
                return new ErrorDataResult<RegisterDto>(registerUser, UserConsts.UserDoesNotSave);
            }

            return new SuccessDataResult<RegisterDto>(registerUser, UserConsts.UserSuccessfullyCreated);
        }

        private IDataResult<DefAdmin> CreateAdmin(RegisterDto registerUser, byte[] passwordHash, byte[] passwordSalt)
        {
            DefAdmin admin = new DefAdmin()
            {
                FirstName = registerUser.FirstName,
                LastName = registerUser.LastName,
                MailAdress = registerUser.Mail,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                RegisterDate = DateTime.Now,
                IsActive = true,
            };

            return _adminService.AddAdmin(admin);
        }
    }
}
