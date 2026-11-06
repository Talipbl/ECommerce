using ECommerce.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations;

public class GnlProductPriceConfiguration : IEntityTypeConfiguration<GnlProductPrice>
{
    public void Configure(EntityTypeBuilder<GnlProductPrice> entity)
    {
        entity.HasKey(e => e.Id).HasName("Gnl_ProductPrices_pk");

        entity.ToTable("Gnl_ProductPrices", "dbo");

        entity.Property(e => e.DiscountExpireDate).HasColumnType("datetime");
        entity.Property(e => e.DiscountPrice).HasColumnType("decimal(18, 2)");
        entity.Property(e => e.DiscountRatio).HasColumnType("decimal(18, 2)");
        entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        entity.Property(e => e.PurchasePrice).HasColumnType("decimal(18, 2)");
        entity.Property(e => e.StatusId).HasDefaultValueSql("((1))");

        entity.HasOne(d => d.Currency).WithMany(p => p.GnlProductPrices)
            .HasForeignKey(d => d.CurrencyId)
            .HasConstraintName("Gnl_ProductPrices_Sys_Currencies_Id_fk");

        entity.HasOne(d => d.Option).WithMany(p => p.GnlProductPrices)
            .HasForeignKey(d => d.OptionId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Gnl_ProductPrices_Gnl_ProductOptions_Id_fk");

        entity.HasOne(d => d.Product).WithMany(p => p.GnlProductPrices)
            .HasForeignKey(d => d.ProductId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Gnl_ProductPrices_Gnl_Products_Id_fk");

        entity.HasOne(d => d.Status).WithMany(p => p.GnlProductPrices)
            .HasForeignKey(d => d.StatusId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Gnl_ProductPrices_Sys_StatusTypes_Id_fk");

        entity.HasOne(d => d.VatRatio).WithMany(p => p.GnlProductPrices)
            .HasForeignKey(d => d.VatRatioId)
            .HasConstraintName("Gnl_ProductPrices_Sys_VatRatios_Id_fk");
    }
}
