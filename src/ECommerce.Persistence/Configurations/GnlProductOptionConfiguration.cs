using ECommerce.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations;

public class GnlProductOptionConfiguration : IEntityTypeConfiguration<GnlProductOption>
{
    public void Configure(EntityTypeBuilder<GnlProductOption> entity)
    {
        entity.HasKey(e => e.Id).HasName("Gnl_ProductOptions_pk");

        entity.ToTable("Gnl_ProductOptions", "dbo");

        entity.Property(e => e.AvailableDate).HasColumnType("datetime");
        entity.Property(e => e.Height).HasColumnType("decimal(18, 0)");
        entity.Property(e => e.IsAvailable)
            .IsRequired()
            .HasDefaultValueSql("((1))");
        entity.Property(e => e.Length).HasColumnType("decimal(18, 0)");
        entity.Property(e => e.OptionName).HasMaxLength(200);
        entity.Property(e => e.StatusId).HasDefaultValueSql("((1))");
        entity.Property(e => e.StockCode).HasMaxLength(15);
        entity.Property(e => e.UnitOfStock).HasColumnType("decimal(18, 0)");
        entity.Property(e => e.Weight).HasColumnType("decimal(18, 0)");
        entity.Property(e => e.Width).HasColumnType("decimal(18, 0)");

        entity.HasOne(d => d.Product).WithMany(p => p.GnlProductOptions)
            .HasForeignKey(d => d.ProductId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Gnl_ProductOptions_Gnl_Products_Id_fk");

        entity.HasOne(d => d.Status).WithMany(p => p.GnlProductOptions)
            .HasForeignKey(d => d.StatusId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Gnl_ProductOptions_Sys_StatusTypes_Id_fk");

        entity.HasOne(d => d.UnitType).WithMany(p => p.GnlProductOptionUnitTypes)
            .HasForeignKey(d => d.UnitTypeId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Gnl_ProductOptions_Sys_UnitTypeId_Id_fk");
    }
}
