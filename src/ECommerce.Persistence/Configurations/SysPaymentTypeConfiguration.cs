using ECommerce.Systems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations;

public class SysPaymentTypeConfiguration : IEntityTypeConfiguration<SysPaymentType>
{
    public void Configure(EntityTypeBuilder<SysPaymentType> entity)
    {
        entity.HasKey(e => e.Id).HasName("Sys_PaymentTypes_pk");

        entity.ToTable("Sys_PaymentTypes", "dbo");

        entity.Property(e => e.PaymentName).HasMaxLength(25);
    }
}
