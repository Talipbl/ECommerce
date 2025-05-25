
namespace ECommerce.Systems
{
    public interface ISystemRepository
    {
        void LogError(SysErrorLog errorLog);
        ICollection<SysCurrency> GetCurriences();
        ICollection<SysStatusType> GetSystemStatus();
        ICollection<SysUnitType> GetUnitTypes();
        ICollection<SysVatRatio> GetVatRatios();
    }
}
