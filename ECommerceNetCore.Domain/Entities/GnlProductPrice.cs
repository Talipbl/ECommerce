using System;
using System.Collections.Generic;

namespace ECommerceNetCore.Domain.Entities;

public partial class GnlProductPrice : BaseEntity
{

    public int ProductId { get; set; }

    public int OptionId { get; set; }

    public decimal Price { get; set; }

    public decimal PurchasePrice { get; set; }

    public decimal DiscountPrice { get; set; }

    public decimal DiscountRatio { get; set; }

    public DateTime? DiscountExpireDate { get; set; }

    public int CurrencyId { get; set; }

    public int VatRatioId { get; set; }

    public int StatusId { get; set; }

    public bool IsSale { get; set; }

    public virtual SysCurrency? Currency { get; set; }

    public virtual GnlProductOption Option { get; set; } = null!;

    public virtual GnlProduct Product { get; set; } = null!;

    public virtual SysStatusType Status { get; set; } = null!;

    public virtual SysVatRatio? VatRatio { get; set; }
}
