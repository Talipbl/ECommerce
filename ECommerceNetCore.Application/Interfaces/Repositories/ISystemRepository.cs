using ECommerceNetCore.Domain.Entities;

namespace ECommerceNetCore.Application.Interfaces
{
    public interface ISystemRepository
    {
        void LogError(SysErrorLog errorLog);
    }
}
