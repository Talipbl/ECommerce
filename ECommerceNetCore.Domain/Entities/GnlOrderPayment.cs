using System;
using System.Collections.Generic;

namespace ECommerceNetCore.Domain.Entities;

public partial class GnlOrderPayment : BaseEntity
{

    public int OrderId { get; set; }

    public int? PaymentTypeId { get; set; }

    public decimal? TotalAmount { get; set; }

    public DateTime PaymentDate { get; set; }

    public int StatusId { get; set; }

    public string? Note { get; set; }

    public int? CurrenciesId { get; set; }

    public virtual SysCurrency? Currencies { get; set; }

    public virtual GnlOrder Order { get; set; } = null!;

    public virtual SysPaymentType? PaymentType { get; set; }

    public virtual SysStatusType Status { get; set; } = null!;
}
