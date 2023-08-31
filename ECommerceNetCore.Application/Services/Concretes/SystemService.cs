using ECommerceNetCore.Application.Aspects;
using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Application.Utilities;
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

        [CacheAspect(Duration = 99999)]
        public IListResult<SysCurrency> GetCurrencies()
        {
            return _systemRepository.GetCurriences();
        }

        [CacheAspect(Duration = 99999)]
        public IListResult<SysStatusType> GetSystemStatus()
        {
            return _systemRepository.GetSystemStatus();
        }

        [CacheAspect(Duration = 99999)]
        public IListResult<SysUnitType> GetUnitTypes()
        {
            return _systemRepository.GetUnitTypes();
        }

        [CacheAspect(Duration = 99999)]
        public IListResult<SysVatRatio> GetVatRatios()
        {
            return _systemRepository.GetVatRatios();
        }

        public void LogError(SysErrorLog errorLog)
        {
            _systemRepository.LogError(errorLog);
        }
    }
}
