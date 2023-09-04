using ECommerce.Application.Utilities.Results.Abstracts;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Interfaces.Services.System
{
    public interface ISystemService
    {
        IListResult<SysCurrency> GetCurrencies();
        IListResult<SysStatusType> GetSystemStatus();
        IListResult<SysUnitType> GetUnitTypes();
        IListResult<SysVatRatio> GetVatRatios();
        void LogError(SysErrorLog errorLog);
    }
}
