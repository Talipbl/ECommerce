using ECommerce.Domain;
using ECommerce.Order;
using System;
using System.Collections.Generic;

namespace ECommerce.Systems;

public partial class SysPaymentType :AggregateRoot<int>
{

    public string? PaymentName { get; set; }

    public virtual ICollection<GnlOrderPayment> GnlOrderPayments { get; } = new List<GnlOrderPayment>();

    public virtual ICollection<GnlOrder> GnlOrders { get; } = new List<GnlOrder>();
}
