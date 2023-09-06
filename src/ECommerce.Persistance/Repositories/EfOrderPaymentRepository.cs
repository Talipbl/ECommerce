using ECommerce.Core.Persistance;
using ECommerce.Persistance;

namespace ECommerce.Order;

public class EfOrderPaymentRepository : EfBaseEntityRepository<GnlOrderPayment, ECommerceContext>, IOrderPaymentRepository
{

}
