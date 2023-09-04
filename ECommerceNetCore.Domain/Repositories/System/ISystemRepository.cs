using ECommerce.Application.Utilities.Results.Abstracts;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Interfaces.Repositories.System
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
