
namespace ECommerce.Systems
{
    public interface ISystemRepository
    {
        void LogError(SysErrorLog errorLog);
        IListResult<SysCurrency> GetCurriences();
        IListResult<SysStatusType> GetSystemStatus();
        IListResult<SysUnitType> GetUnitTypes();
        IListResult<SysVatRatio> GetVatRatios();
    }
}
