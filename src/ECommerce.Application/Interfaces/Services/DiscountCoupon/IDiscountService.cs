using ECommerce.Category;
using Ecommerce.Shared.Utilities.Results;

namespace ECommerce.DiscountCoupon
{
    public interface IDiscountService
    {
        IDataResult<DefDiscountCoupon> AddCoupon(DefDiscountCoupon coupon);
        IResult UpdateCoupon(DefDiscountCoupon admin);
        IResult DeleteCoupon(int couponId);
        IListResult<DefDiscountCoupon> GetCoupons(int productId = 0, int categoryId = (int)CategoryTypes.All, int discountTypeId = (int)DiscountTypes.All);
        IDataResult<DefDiscountCoupon> GetCoupon(int couponId);
        IDataResult<DefDiscountCoupon> GetCoupon(string couponCode);
    }
}
