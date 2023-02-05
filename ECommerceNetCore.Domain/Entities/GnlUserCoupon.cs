using System;
using System.Collections.Generic;

namespace ECommerceNetCore.Domain.Entities;

public partial class GnlUserCoupon : BaseEntity
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
