using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Application.Results;
using ECommerceNetCore.Domain.Entities;

namespace ECommerceNetCore.Application.Services
{
    public class UserService : IUserService
    {
        IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        #region User
        public IDataResult<GnlUser> AddUser(GnlUser user)
        {
            throw new NotImplementedException();
        }

        public IResult DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public IResult UpdateUser(GnlUser user)
        {
            throw new NotImplementedException();
        }

        public IListResult<GnlUser> GetAllUsers(int statudId = 1)
        {
            return _userRepo.GetAllUsers(statudId);
        }

        public IDataResult<GnlUser> GetUser(string userName, string userMail)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region User Address
        public IDataResult<GnlUserAddress> AddUserAddress(GnlUserAddress address)
        {
            throw new NotImplementedException();
        }

        public IResult DeleteUserAddress(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<GnlUserAddress> GetUserAddress(int userId, int addressId = 0, bool isDefault = true)
        {
            throw new NotImplementedException();
        }

        public IListResult<GnlUserAddress> GetUserAddresses(int userId)
        {
            throw new NotImplementedException();
        }

        public IResult UpdateUserAddress(GnlUserAddress address)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region User Coupon
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
        #endregion
    }
}
