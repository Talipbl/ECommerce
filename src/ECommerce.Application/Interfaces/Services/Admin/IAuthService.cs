using Ecommerce.Shared.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Admin;

public interface IAuthService
{
    IDataResult<LoginDto> Login(LoginDto loginUser);
    IDataResult<RegisterDto> Register(RegisterDto registerUser);
}
