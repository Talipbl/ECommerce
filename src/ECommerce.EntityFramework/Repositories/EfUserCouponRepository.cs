using ECommerce.EntityFramework;


namespace ECommerce.User;

public class EfUserCouponRepository : EfBaseEntityRepository<GnlUserCoupon, ECommerceContext>, IUserCouponRepository
{

}
