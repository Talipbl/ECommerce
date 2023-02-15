using ECommerceNetCore.Application.DataTransferObjects;
using ECommerceNetCore.Application.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Application.Interfaces
{
    public interface IAuthService
    {
        IDataResult<LoginDto> Login(LoginDto loginUser);
        IDataResult<RegisterDto> Register(RegisterDto registerUser);
    }
}
