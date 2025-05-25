using ECommerce.Domain;
using ECommerce.Systems;
using ECommerce.User;
using System;
using System.Collections.Generic;

namespace ECommerce.Order;

public partial class GnlOrder : AggregateRoot<int>
{

    public string OrderCode { get; set; } = null!;

    public int UserId { get; set; }

    public decimal OrderAmount { get; set; }

    public decimal? VatAmount { get; set; }

    public decimal? DiscountAmount { get; set; }

    public decimal? ShipAmount { get; set; }

    public int? CarrierId { get; set; }

    public DateTime OrderDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int PaymentTypeId { get; set; }

    public int? CouponId { get; set; }

    public int? StatusId { get; set; }

    public virtual ICollection<GnlOrderPayment> GnlOrderPayments { get; } = new List<GnlOrderPayment>();

    public virtual ICollection<GnlOrderProduct> GnlOrderProducts { get; } = new List<GnlOrderProduct>();

    public virtual SysPaymentType PaymentType { get; set; } = null!;

    public virtual SysStatusType? Status { get; set; }

    public virtual GnlUser User { get; set; } = null!;
}
