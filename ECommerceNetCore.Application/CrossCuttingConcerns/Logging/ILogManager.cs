using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Application.CrossCuttingConcerns
{
    public interface ILogManager
    {
        void LogError(string methodName, string message);
    }
}
