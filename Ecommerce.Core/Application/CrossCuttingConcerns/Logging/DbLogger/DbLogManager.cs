using Ecommerce.Core.Application.CrossCuttingConcerns.Logging;
using ECommerce.Application.Interfaces.Services;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Application.CrossCuttingConcerns.Logging.DbLogger
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
