using ECommerceNetCore.Application.Interfaces.Repositories;
using ECommerceNetCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Application.CrossCuttingConcerns.Logging.DbLogger
{
    public class DbLogManager : ILogManager
    {
        ISystemRepository<SysErrorLog> _systemRepository;
        public DbLogManager(ISystemRepository<SysErrorLog> systemRepository)
        {
            _systemRepository = systemRepository;
        }
        public void LogError(string methodName, string message)
        {
            SysErrorLog errorLog = new SysErrorLog();
            errorLog.MethodName = methodName;
            errorLog.ErrorMessage = message;
            errorLog.CreatedDate = DateTime.Now;

            _systemRepository.LogError(errorLog);
        }
    }
}
