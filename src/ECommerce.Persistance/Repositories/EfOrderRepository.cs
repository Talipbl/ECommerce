using ECommerce.Core.Persistance;
using ECommerce.Persistance;

namespace ECommerce.Order;

public class EfOrderRepository : EfBaseEntityRepository<GnlOrder, ECommerceContext>, IOrderRepository
{

}
