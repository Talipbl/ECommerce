using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Application.CrossCuttingConcerns
{
    public class DbLogManager : ILogManager
    {
        ISystemService _systemSrv;
        public DbLogManager(ISystemService systemSrv)
        {
            _systemSrv = systemSrv;
        }
        public void LogError(string methodName, string message)
        {
            SysErrorLog errorLog = new SysErrorLog();
            errorLog.MethodName = methodName;
            errorLog.ErrorMessage = message;
            errorLog.CreatedDate = DateTime.Now;

            _systemSrv.LogError(errorLog);
        }
    }
}
