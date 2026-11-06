using ECommerce.Xml;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations;

public class GnlXmlSchedulerLogConfiguration : IEntityTypeConfiguration<GnlXmlSchedulerLog>
{
    public void Configure(EntityTypeBuilder<GnlXmlSchedulerLog> entity)
    {
        entity.HasKey(e => e.Id).HasName("Gnl_XmlSchedulereLogs_pk");

        entity.ToTable("Gnl_XmlSchedulerLogs", "dbo");

        entity.Property(e => e.WorkedTime).HasColumnType("datetime");

        entity.HasOne(d => d.Scheduler).WithMany(p => p.GnlXmlSchedulerLogs)
            .HasForeignKey(d => d.SchedulereId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Gnl_XmlSchedulereLogs_Gnl_XmlScheduleres_Id_fk");

        entity.HasOne(d => d.Xml).WithMany(p => p.GnlXmlSchedulerLogs)
            .HasForeignKey(d => d.XmlId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Gnl_XmlSchedulereLogs_Gnl_ProductXmls_Id_fk");
    }
}
