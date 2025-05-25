using ECommerce.EntityFramework;


namespace ECommerce.Order;

public class EfOrderPaymentRepository : EfBaseEntityRepository<GnlOrderPayment, ECommerceContext>, IOrderPaymentRepository
{

}
