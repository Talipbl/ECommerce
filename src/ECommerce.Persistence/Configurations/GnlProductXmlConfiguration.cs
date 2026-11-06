using ECommerce.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations;

public class GnlProductXmlConfiguration : IEntityTypeConfiguration<GnlProductXml>
{
    public void Configure(EntityTypeBuilder<GnlProductXml> entity)
    {
        entity.HasKey(e => e.Id).HasName("Gnl_ProductXmls_pk");

        entity.ToTable("Gnl_ProductXmls", "dbo");

        entity.Property(e => e.AvailableDateTag).HasMaxLength(25);
        entity.Property(e => e.BrandTag).HasMaxLength(25);
        entity.Property(e => e.CategoryNameTag).HasMaxLength(25);
        entity.Property(e => e.CategoryTreeSplitChar).HasMaxLength(25);
        entity.Property(e => e.CategoryTreeTag).HasMaxLength(25);
        entity.Property(e => e.CreatedDate).HasColumnType("datetime");
        entity.Property(e => e.CurrencyTag).HasMaxLength(25);
        entity.Property(e => e.DescriptionTag).HasMaxLength(25);
        entity.Property(e => e.Eantag)
            .HasMaxLength(25)
            .HasColumnName("EANTag");
        entity.Property(e => e.HeadTag).HasMaxLength(25);
        entity.Property(e => e.HeightTag).HasMaxLength(25);
        entity.Property(e => e.Isbntag)
            .HasMaxLength(25)
            .HasColumnName("ISBNTag");
        entity.Property(e => e.Jantag)
            .HasMaxLength(25)
            .HasColumnName("JANTag");
        entity.Property(e => e.LengthTag).HasMaxLength(25);
        entity.Property(e => e.LengthTypeTag).HasMaxLength(25);
        entity.Property(e => e.ManufacturerTag).HasMaxLength(25);
        entity.Property(e => e.MetaDescriptionTag).HasMaxLength(25);
        entity.Property(e => e.MetaKeywordsTag).HasMaxLength(25);
        entity.Property(e => e.MetaTitleTag).HasMaxLength(25);
        entity.Property(e => e.Mpntag)
            .HasMaxLength(25)
            .HasColumnName("MPNTag");
        entity.Property(e => e.OptionTag).HasMaxLength(25);
        entity.Property(e => e.OptionsTag).HasMaxLength(25);
        entity.Property(e => e.PictureTag).HasMaxLength(25);
        entity.Property(e => e.PicturesTag).HasMaxLength(25);
        entity.Property(e => e.PriceTag).HasMaxLength(25);
        entity.Property(e => e.ProductCodeTag).HasMaxLength(25);
        entity.Property(e => e.ProductTag).HasMaxLength(25);
        entity.Property(e => e.PurchasePriceTag).HasMaxLength(25);
        entity.Property(e => e.Skutag)
            .HasMaxLength(25)
            .HasColumnName("SKUTag");
        entity.Property(e => e.StatusTag).HasMaxLength(25);
        entity.Property(e => e.StockQuantityTag).HasMaxLength(25);
        entity.Property(e => e.StockUnitTag).HasMaxLength(25);
        entity.Property(e => e.TitleTag).HasMaxLength(25);
        entity.Property(e => e.Upctag)
            .HasMaxLength(25)
            .HasColumnName("UPCTag");
        entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        entity.Property(e => e.UrlTag).HasMaxLength(25);
        entity.Property(e => e.VatRatioTag).HasMaxLength(25);
        entity.Property(e => e.WeightTag).HasMaxLength(25);
        entity.Property(e => e.WidthTag).HasMaxLength(25);
        entity.Property(e => e.XmlLink).HasMaxLength(250);

        entity.HasOne(d => d.Status).WithMany(p => p.GnlProductXmls)
            .HasForeignKey(d => d.StatusId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Gnl_ProductXmls_Sys_StatusTypes_Id_fk");
    }
}
