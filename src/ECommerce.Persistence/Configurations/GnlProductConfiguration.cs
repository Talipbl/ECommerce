using ECommerce.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations;

public class GnlProductConfiguration : IEntityTypeConfiguration<GnlProduct>
{
    public void Configure(EntityTypeBuilder<GnlProduct> entity)
    {
        entity.HasKey(e => e.Id).HasName("Gnl_Products_pk");

        entity.ToTable("Gnl_Products", "dbo");

        entity.Property(e => e.CreatedDate).HasColumnType("datetime");
        entity.Property(e => e.Ean)
            .HasMaxLength(20)
            .HasColumnName("EAN");
        entity.Property(e => e.Isbn)
            .HasMaxLength(20)
            .HasColumnName("ISBN");
        entity.Property(e => e.Jan)
            .HasMaxLength(20)
            .HasColumnName("JAN");
        entity.Property(e => e.MinmumOrder).HasDefaultValueSql("((1))");
        entity.Property(e => e.Mpn)
            .HasMaxLength(20)
            .HasColumnName("MPN");
        entity.Property(e => e.Name).HasMaxLength(100);
        entity.Property(e => e.SellerCode).HasMaxLength(20);
        entity.Property(e => e.SellerUrl).HasMaxLength(250);
        entity.Property(e => e.StatusId).HasDefaultValueSql("((1))");
        entity.Property(e => e.StockCode).HasMaxLength(15);
        entity.Property(e => e.Upc)
            .HasMaxLength(20)
            .HasColumnName("UPC");
        entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

        entity.HasOne(d => d.Brand).WithMany(p => p.GnlProducts)
            .HasForeignKey(d => d.BrandId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Gnl_Products_Def_Brands_Id_fk");

        entity.HasOne(d => d.Category).WithMany(p => p.GnlProducts)
            .HasForeignKey(d => d.CategoryId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Gnl_Products_Def_Categories_Id_fk");

        entity.HasOne(d => d.Manufacturer).WithMany(p => p.GnlProducts)
            .HasForeignKey(d => d.ManufacturerId)
            .HasConstraintName("Gnl_Products_Def_Manufacturers_Id_fk");

        entity.HasOne(d => d.Status).WithMany(p => p.GnlProducts)
            .HasForeignKey(d => d.StatusId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Gnl_Products_Sys_StatusTypes_Id_fk");
    }
}
