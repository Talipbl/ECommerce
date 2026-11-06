using ECommerce.Systems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations;

public class SysStatusTypeConfiguration : IEntityTypeConfiguration<SysStatusType>
{
    public void Configure(EntityTypeBuilder<SysStatusType> entity)
    {
        entity.HasKey(e => e.Id).HasName("Sys_StatusTypes_pk");

        entity.ToTable("Sys_StatusTypes", "dbo");

        entity.Property(e => e.StatusName).HasMaxLength(25);
    }
}
