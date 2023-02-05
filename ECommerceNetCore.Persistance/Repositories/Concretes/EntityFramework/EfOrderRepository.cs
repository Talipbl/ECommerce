using ECommerceNetCore.Application.Interfaces.Repositories;
using ECommerceNetCore.Domain.Entities;
using ECommerceNetCore.Persistance.Context;

namespace ECommerceNetCore.Persistance.Repositories.Concretes.EntityFramework
{
    public class EfOrderRepository : EfBaseEntityRepository<GnlOrder, EcommerceNetCoreContext>, IOrderRepository
    {

    }
}
