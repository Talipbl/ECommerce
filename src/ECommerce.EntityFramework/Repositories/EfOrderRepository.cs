using ECommerce.EntityFramework;


namespace ECommerce.Order;

public class EfOrderRepository : EfBaseEntityRepository<GnlOrder, ECommerceContext>, IOrderRepository
{

}
