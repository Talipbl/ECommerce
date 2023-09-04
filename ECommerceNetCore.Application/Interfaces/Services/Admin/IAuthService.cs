using ECommerce.Application.DataTransferObjects.Authentications;
using ECommerce.Application.Utilities.Results.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Interfaces.Services.Admin
{
    public interface IAuthService
    {
        IDataResult<LoginDto> Login(LoginDto loginUser);
        IDataResult<RegisterDto> Register(RegisterDto registerUser);
    }
}
