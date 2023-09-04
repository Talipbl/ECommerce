using ECommerce.Core.Persistance;
using ECommerce.Persistance.Context;

namespace ECommerce.User
{
    public class EfUserCouponRepository : EfBaseEntityRepository<GnlUserCoupon, ECommerceContext>, IUserCouponRepository
    {

    }
}
