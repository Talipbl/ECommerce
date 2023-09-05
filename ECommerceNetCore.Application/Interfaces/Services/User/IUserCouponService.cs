using ECommerce.Core.Application;
using ECommerce.Systems;

namespace ECommerce.User;

public interface IUserCouponService
{
    IDataResult<GnlUserCoupon> AddUserCoupon(GnlUserCoupon coupon);
    IResult UpdateUserCoupon(GnlUserCoupon coupon);
    IResult DeleteUserCoupon(int id);
    IListResult<GnlUserCoupon> GetUserCoupons(int userId, int isUsed = (int)StatusTypes.All);
    IDataResult<GnlUserCoupon> GetUserCoupon(int couponId, int userId);
    IResult MarkAsUsed(int couponId);
}
