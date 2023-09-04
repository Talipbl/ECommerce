using System;
using System.Collections.Generic;

namespace ECommerce.Domain.Entities;

public partial class GnlProductOption : AggregateRoot
{

    public int ProductId { get; set; }

    public string OptionName { get; set; } = null!;

    public string StockCode { get; set; }

    public decimal UnitOfStock { get; set; }

    public int UnitTypeId { get; set; }

    public decimal Length { get; set; }

    public decimal Height { get; set; }

    public decimal Width { get; set; }

    public decimal Weight { get; set; }

    public int StatusId { get; set; }

    public bool IsAvailable { get; set; }

    public DateTime? AvailableDate { get; set; }

    public virtual ICollection<GnlProductImage> GnlProductImages { get; } = new List<GnlProductImage>();

    public virtual ICollection<GnlProductPrice> GnlProductPrices { get; } = new List<GnlProductPrice>();

    public virtual GnlProduct Product { get; set; } = null!;

    public virtual SysStatusType Status { get; set; } = null!;

    public virtual SysUnitType UnitType { get; set; } = null!;
}
