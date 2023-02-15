using ECommerceNetCore.Application.Interfaces.Repositories;
using ECommerceNetCore.Domain.Entities;
using ECommerceNetCore.Persistance.Context;

namespace ECommerceNetCore.Persistance.Repositories.Concretes.EntityFramework
{
    public class EfSystemRepository<TEntity> : EfBaseEntityRepository<TEntity, EcommerceNetCoreContext>, ISystemRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        public void LogError(SysErrorLog errorLog)
        {
            this.Add(errorLog as TEntity);
        }
    }
}
