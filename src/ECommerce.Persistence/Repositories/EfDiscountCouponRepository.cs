using ECommerce.Core.Persistence;
using ECommerce.Persistence;

namespace ECommerce.DiscountCoupon;

public class EfDiscountCouponRepository : EfBaseEntityRepository<DefDiscountCoupon, ECommerceContext>, IDiscountCouponRepository
{

}
