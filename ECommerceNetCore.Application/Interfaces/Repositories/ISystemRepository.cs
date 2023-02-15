using ECommerceNetCore.Domain.Entities;

namespace ECommerceNetCore.Application.Interfaces.Repositories
{
    public interface ISystemRepository<TEntity> : IBaseEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        void LogError(SysErrorLog errorLog);
    }
}
