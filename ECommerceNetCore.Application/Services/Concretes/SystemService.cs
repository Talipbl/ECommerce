using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Domain.Entities;

namespace ECommerceNetCore.Application.Services
{

    public class SystemService : ISystemService
    {
        ISystemRepository _systemRepository;
        public SystemService(ISystemRepository systemRepository)
        {
            _systemRepository = systemRepository;
        }
        public void LogError(SysErrorLog errorLog)
        {
            _systemRepository.LogError(errorLog);
        }
    }
}
