using System;
using System.Collections.Generic;

namespace ECommerceNetCore.Domain.Entities;

public partial class GnlProductXml : BaseEntity
{

    public string XmlLink { get; set; } = null!;

    public string? HeadTag { get; set; }

    public string? ProductTag { get; set; }

    public string? ProductCodeTag { get; set; }

    public string? AvailableDateTag { get; set; }

    public string? UrlTag { get; set; }

    public string? PicturesTag { get; set; }

    public string? PictureTag { get; set; }

    public string? OptionsTag { get; set; }

    public string? OptionTag { get; set; }

    public string? TitleTag { get; set; }

    public string? MetaTitleTag { get; set; }

    public string? BrandTag { get; set; }

    public string? ManufacturerTag { get; set; }

    public string? DescriptionTag { get; set; }

    public string? MetaDescriptionTag { get; set; }

    public string? MetaKeywordsTag { get; set; }

    public string? CategoryNameTag { get; set; }

    public string? CategoryTreeTag { get; set; }

    public string? CategoryTreeSplitChar { get; set; }

    public string? PriceTag { get; set; }

    public string? PurchasePriceTag { get; set; }

    public string? VatRatioTag { get; set; }

    public string? CurrencyTag { get; set; }

    public string? StockQuantityTag { get; set; }

    public string? StockUnitTag { get; set; }

    public string? Skutag { get; set; }

    public string? Upctag { get; set; }

    public string? Eantag { get; set; }

    public string? Jantag { get; set; }

    public string? Isbntag { get; set; }

    public string? Mpntag { get; set; }

    public string? LengthTag { get; set; }

    public string? WidthTag { get; set; }

    public string? HeightTag { get; set; }

    public string? WeightTag { get; set; }

    public string? LengthTypeTag { get; set; }

    public string? StatusTag { get; set; }

    public int StatusId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<GnlXmlSchedulerLog> GnlXmlSchedulereLogs { get; } = new List<GnlXmlSchedulerLog>();

    public virtual ICollection<GnlXmlScheduler> GnlXmlScheduleres { get; } = new List<GnlXmlScheduler>();

    public virtual SysStatusType Status { get; set; } = null!;
}
