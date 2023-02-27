using ECommerceNetCore.Application.Results;
using ECommerceNetCore.Domain.Entities;

namespace ECommerceNetCore.Application.Interfaces
{
    public interface ISystemRepository
    {
        void LogError(SysErrorLog errorLog);
        IListResult<SysCurrency> GetCurriences();
        IListResult<SysStatusType> GetSystemStatus();
        IListResult<SysUnitType> GetUnitTypes();
        IListResult<SysVatRatio> GetVatRatios();

        //System verileri için repo kodu yazılacak.
    }
}
