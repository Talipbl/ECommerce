using System;
using System.Collections.Generic;

namespace ECommerce.Domain.Entities;

public partial class SysPaymentType :AggregateRoot
{

    public string? PaymentName { get; set; }

    public virtual ICollection<GnlOrderPayment> GnlOrderPayments { get; } = new List<GnlOrderPayment>();

    public virtual ICollection<GnlOrder> GnlOrders { get; } = new List<GnlOrder>();
}
