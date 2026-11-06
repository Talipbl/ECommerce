using ECommerce.Systems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations;

public class SysErrorLogConfiguration : IEntityTypeConfiguration<SysErrorLog>
{
    public void Configure(EntityTypeBuilder<SysErrorLog> entity)
    {
        entity.HasKey(e => e.Id).HasName("Sys_ErrorLogs_pk");

        entity.ToTable("Sys_ErrorLogs", "dbo");

        entity.Property(e => e.ErrorMessage).HasMaxLength(2500);
        entity.Property(e => e.MethodName).HasMaxLength(2500);
    }
}
