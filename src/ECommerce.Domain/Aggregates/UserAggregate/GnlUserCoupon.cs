using ECommerce.Domain;
using ECommerce.DiscountCoupon;
using System;
using System.Collections.Generic;

namespace ECommerce.User;

public partial class GnlUserCoupon : AggregateRoot<int>
{

    public int UserId { get; set; }

    public int CouponId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UsedDate { get; set; }

    public bool? IsUsed { get; set; }

    public DateTime? ExpireDate { get; set; }

    public virtual DefDiscountCoupon Coupon { get; set; } = null!;

    public virtual GnlUser User { get; set; } = null!;
}
