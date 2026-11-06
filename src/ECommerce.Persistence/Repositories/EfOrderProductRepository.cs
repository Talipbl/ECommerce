using ECommerce.Core.Persistence;
using ECommerce.Persistence;

namespace ECommerce.Order;

public class EfOrderProductRepository : EfBaseEntityRepository<GnlOrderProduct, ECommerceContext>, IOrderProductRepository
{

}
