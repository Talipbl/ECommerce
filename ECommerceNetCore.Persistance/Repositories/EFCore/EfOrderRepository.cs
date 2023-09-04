using ECommerce.Core.Persistance;
using ECommerce.Persistance.Context;

namespace ECommerce.Order
{
    public class EfOrderRepository : EfBaseEntityRepository<GnlOrder, ECommerceContext>, IOrderRepository
    {

    }
}
