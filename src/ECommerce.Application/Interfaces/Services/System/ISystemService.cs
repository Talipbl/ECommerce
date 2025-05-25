using Ecommerce.Shared.Utilities.Results;

namespace ECommerce.Systems;

public interface ISystemService
{
    IListResult<SysCurrency> GetCurrencies();
    IListResult<SysStatusType> GetSystemStatus();
    IListResult<SysUnitType> GetUnitTypes();
    IListResult<SysVatRatio> GetVatRatios();
    void LogError(SysErrorLog errorLog);
}
