using ECommerce.EntityFramework;


namespace ECommerce.DiscountCoupon;

public class EfDiscountCouponRepository : EfBaseEntityRepository<DefDiscountCoupon, ECommerceContext>, IDiscountCouponRepository
{

}
