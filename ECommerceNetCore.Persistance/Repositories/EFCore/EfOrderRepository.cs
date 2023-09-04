using ECommerce.Application.Interfaces.Repositories;
using ECommerce.Domain.Entities;
using ECommerce.Persistance.Context;

namespace ECommerce.Persistance.Repositories.EFCore
{
    public class EfOrderRepository : EfBaseEntityRepository<GnlOrder, ECommerceContext>, IOrderRepository
    {

    }
}
