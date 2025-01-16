using ECommerce.Core.Persistance;
using ECommerce.Persistance;

namespace ECommerce.User;

public class EfUserCouponRepository : EfBaseEntityRepository<GnlUserCoupon, ECommerceContext>, IUserCouponRepository
{

}
