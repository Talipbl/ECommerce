using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Domain.Entities;
using ECommerceNetCore.Persistance.Context;

namespace ECommerceNetCore.Persistance.Repositories.EntityFrameworkCore
{
    public class EfXmlSchedulereLogRepository : EfBaseEntityRepository<GnlXmlSchedulerLog, EcommerceNetCoreContext>, IXmlSchedulereLogRepository
    {

    }
}
