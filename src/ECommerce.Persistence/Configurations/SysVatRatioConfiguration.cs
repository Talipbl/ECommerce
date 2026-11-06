using ECommerce.Systems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations;

public class SysVatRatioConfiguration : IEntityTypeConfiguration<SysVatRatio>
{
    public void Configure(EntityTypeBuilder<SysVatRatio> entity)
    {
        entity.HasKey(e => e.Id).HasName("Sys_VatRatios_pk");

        entity.ToTable("Sys_VatRatios", "dbo");

        entity.Property(e => e.VatRatioValue).HasColumnType("decimal(18, 0)");
    }
}
