using ECommerce.Systems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations;

public class SysMailTypeConfiguration : IEntityTypeConfiguration<SysMailType>
{
    public void Configure(EntityTypeBuilder<SysMailType> entity)
    {
        entity.HasKey(e => e.Id).HasName("Sys_MailTypes_pk");

        entity.ToTable("Sys_MailTypes", "dbo");

        entity.Property(e => e.MailTypeName).HasMaxLength(50);
    }
}
