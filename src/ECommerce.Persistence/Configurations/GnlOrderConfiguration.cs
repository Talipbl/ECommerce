using ECommerce.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations;

public class GnlOrderConfiguration : IEntityTypeConfiguration<GnlOrder>
{
    public void Configure(EntityTypeBuilder<GnlOrder> entity)
    {
        entity.HasKey(e => e.Id).HasName("Gnl_Orders_pk");

        entity.ToTable("Gnl_Orders", "dbo");

        entity.Property(e => e.DiscountAmount).HasColumnType("decimal(18, 0)");
        entity.Property(e => e.OrderAmount).HasColumnType("decimal(18, 0)");
        entity.Property(e => e.OrderCode).HasMaxLength(20);
        entity.Property(e => e.OrderDate).HasColumnType("datetime");
        entity.Property(e => e.ShipAmount).HasColumnType("decimal(18, 0)");
        entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        entity.Property(e => e.VatAmount).HasColumnType("decimal(18, 0)");

        entity.HasOne(d => d.PaymentType).WithMany(p => p.GnlOrders)
            .HasForeignKey(d => d.PaymentTypeId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Gnl_Orders_Sys_PaymentTypes_Id_fk");

        entity.HasOne(d => d.Status).WithMany(p => p.GnlOrders)
            .HasForeignKey(d => d.StatusId)
            .HasConstraintName("Gnl_Orders_Sys_StatusTypes_Id_fk");

        entity.HasOne(d => d.User).WithMany(p => p.GnlOrders)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Gnl_Orders_Gnl_Users_Id_fk");
    }
}
