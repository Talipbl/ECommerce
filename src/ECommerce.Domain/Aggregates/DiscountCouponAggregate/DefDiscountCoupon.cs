using ECommerce.Domain;
using ECommerce.Category;
using ECommerce.Product;
using ECommerce.User;

namespace ECommerce.DiscountCoupon;

public partial class DefDiscountCoupon : AggregateRoot<int>
{

    public string CouponName { get; set; } = null!;

    public string? CouponCode { get; set; }

    public int? CategoryId { get; set; }

    public int? SubCategoryId { get; set; }

    public decimal DiscountRate { get; set; }

    public decimal? MinumumOrder { get; set; }

    public bool DiscountType { get; set; }

    public int ProductId { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual DefCategory? Category { get; set; }

    public virtual ICollection<GnlUserCoupon> GnlUserCoupons { get; } = new List<GnlUserCoupon>();

    public virtual GnlProduct Product { get; set; } = null!;

    public virtual DefSubCategory? SubCategory { get; set; }
}
