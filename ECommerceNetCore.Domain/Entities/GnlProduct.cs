using System;
using System.Collections.Generic;

namespace ECommerceNetCore.Domain.Entities;

public partial class GnlProduct : BaseEntity
{

    public int BrandId { get; set; }

    public string? Name { get; set; }

    public string Description { get; set; } = null!;

    public int? ManufacturerId { get; set; }

    public string? Upc { get; set; }

    public string? Ean { get; set; }

    public string? Jan { get; set; }

    public string? Isbn { get; set; }

    public string? Mpn { get; set; }

    public int MinmumOrder { get; set; }

    public int CategoryId { get; set; }

    public int StatusId { get; set; }

    public bool? IsAvailable { get; set; }

    public int? XmlId { get; set; }

    public string? SellerCode { get; set; }

    public string? SellerUrl { get; set; }

    public DateTime? AvailableDate { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual DefBrand Brand { get; set; } = null!;

    public virtual DefCategory Category { get; set; } = null!;

    public virtual ICollection<DefDiscountCoupon> DefDiscountCoupons { get; } = new List<DefDiscountCoupon>();

    public virtual ICollection<GnlOrderProduct> GnlOrderProducts { get; } = new List<GnlOrderProduct>();

    public virtual ICollection<GnlProductCategory> GnlProductCategories { get; } = new List<GnlProductCategory>();

    public virtual ICollection<GnlProductImage> GnlProductImages { get; } = new List<GnlProductImage>();

    public virtual ICollection<GnlProductOption> GnlProductOptions { get; } = new List<GnlProductOption>();

    public virtual ICollection<GnlProductPrice> GnlProductPrices { get; } = new List<GnlProductPrice>();

    public virtual DefManufacturer? Manufacturer { get; set; }

    public virtual SysStatusType Status { get; set; } = null!;
}
