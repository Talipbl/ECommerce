using ECommerce.Systems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations;

public class SysUnitTypeConfiguration : IEntityTypeConfiguration<SysUnitType>
{
    public void Configure(EntityTypeBuilder<SysUnitType> entity)
    {
        entity.HasKey(e => e.Id).HasName("Sys_UnitTypeId_pk");

        entity.ToTable("Sys_UnitTypes", "dbo");

        entity.Property(e => e.TypeName).HasMaxLength(15);
    }
}
