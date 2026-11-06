using ECommerce.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations;

public class GnlOrderPaymentConfiguration : IEntityTypeConfiguration<GnlOrderPayment>
{
    public void Configure(EntityTypeBuilder<GnlOrderPayment> entity)
    {
        entity.HasKey(e => e.Id).HasName("Gnl_OrderPayments_pk");

        entity.ToTable("Gnl_OrderPayments", "dbo");

        entity.Property(e => e.Note).HasMaxLength(2000);
        entity.Property(e => e.PaymentDate).HasColumnType("datetime");
        entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 0)");

        entity.HasOne(d => d.Currencies).WithMany(p => p.GnlOrderPayments)
            .HasForeignKey(d => d.CurrenciesId)
            .HasConstraintName("Gnl_OrderPayments_Sys_Currencies_Id_fk");

        entity.HasOne(d => d.Order).WithMany(p => p.GnlOrderPayments)
            .HasForeignKey(d => d.OrderId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Gnl_OrderPayments_Gnl_Orders_Id_fk");

        entity.HasOne(d => d.PaymentType).WithMany(p => p.GnlOrderPayments)
            .HasForeignKey(d => d.PaymentTypeId)
            .HasConstraintName("Gnl_OrderPayments_Sys_PaymentTypes_Id_fk");

        entity.HasOne(d => d.Status).WithMany(p => p.GnlOrderPayments)
            .HasForeignKey(d => d.StatusId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Gnl_OrderPayments_Sys_StatusTypes_Id_fk");
    }
}
