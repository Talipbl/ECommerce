using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Application.Utilities;
using ECommerceNetCore.Domain.Entities;

namespace ECommerceNetCore.Application.Services
{
    public class DiscountService : IDiscountService
    {
        public IDataResult<DefDiscountCoupon> AddCoupon(DefDiscountCoupon coupon)
        {
            throw new NotImplementedException();
        }

        public IResult DeleteCoupon(int couponId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<DefDiscountCoupon> GetCoupon(int couponId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<DefDiscountCoupon> GetCoupon(string couponCode)
        {
            throw new NotImplementedException();
        }

        public IListResult<DefDiscountCoupon> GetCoupons(int productId = 0, int categoryId = 0, int discountTypeId = 0)
        {
            throw new NotImplementedException();
        }

        public IResult UpdateCoupon(DefDiscountCoupon admin)
        {
            throw new NotImplementedException();
        }
    }
}
