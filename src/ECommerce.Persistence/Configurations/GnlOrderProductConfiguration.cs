using ECommerce.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations;

public class GnlOrderProductConfiguration : IEntityTypeConfiguration<GnlOrderProduct>
{
    public void Configure(EntityTypeBuilder<GnlOrderProduct> entity)
    {
        entity.HasKey(e => e.Id).HasName("Gnl_OrderProducts_pk");

        entity.ToTable("Gnl_OrderProducts", "dbo");

        entity.Property(e => e.DiscountAmount).HasColumnType("decimal(18, 0)");
        entity.Property(e => e.Quantity).HasColumnType("decimal(18, 0)");
        entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 0)");
        entity.Property(e => e.VatAmount).HasColumnType("decimal(18, 0)");

        entity.HasOne(d => d.Order).WithMany(p => p.GnlOrderProducts)
            .HasForeignKey(d => d.OrderId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Gnl_OrderProducts_Gnl_Orders_Id_fk");

        entity.HasOne(d => d.Product).WithMany(p => p.GnlOrderProducts)
            .HasForeignKey(d => d.ProductId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Gnl_OrderProducts_Gnl_Products_Id_fk");
    }
}
