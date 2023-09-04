using ECommerce.Core.Persistance;
using ECommerce.Persistance.Context;

namespace ECommerce.DiscountCoupon
{
    public class EfDiscountCouponRepository : EfBaseEntityRepository<DefDiscountCoupon, ECommerceContext>, IDiscountCouponRepository
    {

    }
}
