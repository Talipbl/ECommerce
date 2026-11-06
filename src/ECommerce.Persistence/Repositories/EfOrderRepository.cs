using ECommerce.Core.Persistence;
using ECommerce.Persistence;

namespace ECommerce.Order;

public class EfOrderRepository : EfBaseEntityRepository<GnlOrder, ECommerceContext>, IOrderRepository
{

}
