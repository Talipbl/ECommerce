using ECommerce.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations;

public class GnlProductImageConfiguration : IEntityTypeConfiguration<GnlProductImage>
{
    public void Configure(EntityTypeBuilder<GnlProductImage> entity)
    {
        entity.HasKey(e => e.Id).HasName("Gnl_ProductImages_pk");

        entity.ToTable("Gnl_ProductImages", "dbo");

        entity.Property(e => e.ImageUrl).HasMaxLength(250);

        entity.HasOne(d => d.Option).WithMany(p => p.GnlProductImages)
            .HasForeignKey(d => d.OptionId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Gnl_ProductImages_Gnl_ProductOptions_Id_fk");

        entity.HasOne(d => d.Product).WithMany(p => p.GnlProductImages)
            .HasForeignKey(d => d.ProductId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Gnl_ProductImages_Gnl_Products_Id_fk");
    }
}
