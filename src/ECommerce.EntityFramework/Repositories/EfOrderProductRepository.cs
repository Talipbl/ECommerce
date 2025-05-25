using ECommerce.EntityFramework;


namespace ECommerce.Order;

public class EfOrderProductRepository : EfBaseEntityRepository<GnlOrderProduct, ECommerceContext>, IOrderProductRepository
{

}
