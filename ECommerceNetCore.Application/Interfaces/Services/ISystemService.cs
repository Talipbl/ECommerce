using ECommerceNetCore.Application.Utilities;
using ECommerceNetCore.Domain.Entities;

namespace ECommerceNetCore.Application.Interfaces
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
