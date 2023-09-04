using ECommerce.Core.Persistance;
using ECommerce.Persistance.Context;

namespace ECommerce.Order
{
    public class EfOrderProductRepository : EfBaseEntityRepository<GnlOrderProduct, ECommerceContext>, IOrderProductRepository
    {

    }
}
