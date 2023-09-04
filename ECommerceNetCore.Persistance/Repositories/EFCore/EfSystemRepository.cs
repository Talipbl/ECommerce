using ECommerce.Core.Persistance;
using ECommerce.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Systems;

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

    public ICollection<SysCurrency> GetCurriences()
    {
        var result = GetAll<SysCurrency>().ToList();
        return result;
    }

    public ICollection<SysStatusType> GetSystemStatus()
    {
        var result = GetAll<SysStatusType>().ToList();
        return result;
    }

    public ICollection<SysUnitType> GetUnitTypes()
    {
        var result = GetAll<SysUnitType>().ToList();
        return result;
    }

    public ICollection<SysVatRatio> GetVatRatios()
    {
        var result = GetAll<SysVatRatio>().ToList();
        return result;
    }
}
