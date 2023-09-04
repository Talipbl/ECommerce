using ECommerce.Core.Persistance;
using ECommerce.Persistance.Context;

namespace ECommerce.Order
{
    public class EfOrderPaymentRepository : EfBaseEntityRepository<GnlOrderPayment, ECommerceContext>, IOrderPaymentRepository
    {

    }
}
