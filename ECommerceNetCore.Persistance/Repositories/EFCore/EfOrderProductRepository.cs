using ECommerce.Core.Persistance;
using ECommerce.Persistance;

namespace ECommerce.Order;

public class EfOrderProductRepository : EfBaseEntityRepository<GnlOrderProduct, ECommerceContext>, IOrderProductRepository
{

}
