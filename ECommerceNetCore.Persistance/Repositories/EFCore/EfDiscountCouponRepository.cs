using ECommerce.Core.Persistance;
using ECommerce.Persistance;

namespace ECommerce.DiscountCoupon;

public class EfDiscountCouponRepository : EfBaseEntityRepository<DefDiscountCoupon, ECommerceContext>, IDiscountCouponRepository
{

}
