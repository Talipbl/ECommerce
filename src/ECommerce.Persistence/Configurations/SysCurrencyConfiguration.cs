using ECommerce.Systems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations;

public class SysCurrencyConfiguration : IEntityTypeConfiguration<SysCurrency>
{
    public void Configure(EntityTypeBuilder<SysCurrency> entity)
    {
        entity.HasKey(e => e.Id).HasName("Sys_Currencies_pk");

        entity.ToTable("Sys_Currencies", "dbo");

        entity.Property(e => e.CurrencyCode).HasMaxLength(10);
        entity.Property(e => e.CurrencyName).HasMaxLength(25);
        entity.Property(e => e.Icon).HasMaxLength(1);
    }
}
