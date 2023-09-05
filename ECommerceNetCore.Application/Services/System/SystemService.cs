using ECommerce.Core.Application;

namespace ECommerce.Systems
{
    public class SystemService : ISystemService
    {
        //TO-DO: Burası düznelenecek
        ISystemRepository _systemRepository;
        public SystemService(ISystemRepository systemRepository)
        {
            _systemRepository = systemRepository;
        }

        [CacheAspect(Duration = 99999)]
        public IListResult<SysCurrency> GetCurrencies()
        {
            var reult = _systemRepository.GetCurriences();
            return null;
        }

        [CacheAspect(Duration = 99999)]
        public IListResult<SysStatusType> GetSystemStatus()
        {
            var result = _systemRepository.GetSystemStatus(); 
            return null;
        }

        [CacheAspect(Duration = 99999)]
        public IListResult<SysUnitType> GetUnitTypes()
        {
            var result = _systemRepository.GetUnitTypes();
            return null;
        }

        [CacheAspect(Duration = 99999)]
        public IListResult<SysVatRatio> GetVatRatios()
        {
            var result = _systemRepository.GetVatRatios();
            return null;
        }

        public void LogError(SysErrorLog errorLog)
        {
            _systemRepository.LogError(errorLog);
        }
    }
}
