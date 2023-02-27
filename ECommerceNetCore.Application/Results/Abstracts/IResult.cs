using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Application.Results
{
    public interface IResult
    {
        bool Success { get;}
        string Message { get;}
        string Additional { get;}
    }
}
