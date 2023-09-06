using ECommerce.Core.Application;

namespace ECommerce.User;

public class UserCouponService : IUserCouponService
{
    public IDataResult<GnlUserCoupon> AddUserCoupon(GnlUserCoupon coupon)
    {
        throw new NotImplementedException();
    }

    public IResult DeleteUserCoupon(int id)
    {
        throw new NotImplementedException();
    }

    public IDataResult<GnlUserCoupon> GetUserCoupon(int couponId, int userId)
    {
        throw new NotImplementedException();
    }

    public IListResult<GnlUserCoupon> GetUserCoupons(int userId, int isUsed = 0)
    {
        throw new NotImplementedException();
    }

    public IResult MarkAsUsed(int couponId)
    {
        throw new NotImplementedException();
    }

    public IResult UpdateUserCoupon(GnlUserCoupon coupon)
    {
        throw new NotImplementedException();
    }
}
