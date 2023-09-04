using ECommerce.Core.Persistance;
using ECommerce.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace ECommerce.Systems
{
    public class EfSystemRepository : EfBaseEntityRepository<SysStatusType, ECommerceContext>, ISystemRepository
    {
        private object BaseOperation(object entity, EntityState state)
        {
            using (ECommerceContext context = new ECommerceContext())
            {
                context.Entry(entity).State = state;
                if (context.SaveChanges() > 0)
                {
                    return entity;
                }
                return entity;
            }
        }
        public void LogError(SysErrorLog errorLog)
        {
            BaseOperation(errorLog, EntityState.Added);
        }

        public IListResult<SysCurrency> GetCurriences()
        {
            var result = GetAll<SysCurrency>().ToList();
            return new ListResult<SysCurrency>(result, result.Count);
        }

        public IListResult<SysStatusType> GetSystemStatus()
        {
            var result = GetAll<SysStatusType>().ToList();
            return new ListResult<SysStatusType>(result, result.Count);
        }

        public IListResult<SysUnitType> GetUnitTypes()
        {
            var result = GetAll<SysUnitType>().ToList();
            return new ListResult<SysUnitType>(result, result.Count);
        }

        public IListResult<SysVatRatio> GetVatRatios()
        {
            var result = GetAll<SysVatRatio>().ToList();
            return new ListResult<SysVatRatio>(result, result.Count);
        }
    }
}
