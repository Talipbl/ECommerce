using ECommerceNetCore.Application.Results;
using ECommerceNetCore.Domain.Common;
using ECommerceNetCore.Domain.Entities;

namespace ECommerceNetCore.Application.Interfaces
{
    public interface IUserService
    {
        #region User
        IDataResult<GnlUser> AddUser(GnlUser user);
        IResult UpdateUser(GnlUser user);
        IResult DeleteUser(int id);
        IListResult<GnlUser> GetAllUsers(int statudId = (int)StatusTypes.Active, int start = 0, int take = 25);
        IDataResult<GnlUser> GetUser(string userName, string userMail);
        #endregion

        #region User Address
        IDataResult<GnlUserAddress> AddUserAddress(GnlUserAddress address);
        IResult UpdateUserAddress(GnlUserAddress address);
        IResult DeleteUserAddress(int id);
        IListResult<GnlUserAddress> GetUserAddresses(int userId);
        IDataResult<GnlUserAddress> GetUserAddress(int userId, int addressId = 0, bool isDefault = true);
        #endregion

        #region User Coupon
        IDataResult<GnlUserCoupon> AddUserCoupon(GnlUserCoupon coupon);
        IResult UpdateUserCoupon(GnlUserCoupon coupon);
        IResult DeleteUserCoupon(int id);
        IListResult<GnlUserCoupon> GetUserCoupons(int userId, int isUsed = (int)StatusTypes.All);
        IDataResult<GnlUserCoupon> GetUserCoupon(int couponId, int userId);
        IResult MarkAsUsed(int couponId);
        #endregion
    }
}
