using ECommerce.Core.Persistence;
using ECommerce.Persistence;

namespace ECommerce.Order;

public class EfOrderPaymentRepository : EfBaseEntityRepository<GnlOrderPayment, ECommerceContext>, IOrderPaymentRepository
{

}
