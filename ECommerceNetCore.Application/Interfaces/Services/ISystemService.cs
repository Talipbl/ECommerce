using ECommerceNetCore.Domain.Entities;

namespace ECommerceNetCore.Application.Interfaces
{
    public interface ISystemService
    {
        void LogError(SysErrorLog errorLog);
    }
}
