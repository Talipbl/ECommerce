using ECommerce.Core.Persistence;
using ECommerce.Persistence;

namespace ECommerce.User;

public class EfUserCouponRepository : EfBaseEntityRepository<GnlUserCoupon, ECommerceContext>, IUserCouponRepository
{

}
