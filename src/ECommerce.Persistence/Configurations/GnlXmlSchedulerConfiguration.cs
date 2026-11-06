using ECommerce.Xml;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations;

public class GnlXmlSchedulerConfiguration : IEntityTypeConfiguration<GnlXmlScheduler>
{
    public void Configure(EntityTypeBuilder<GnlXmlScheduler> entity)
    {
        entity.HasKey(e => e.Id).HasName("Gnl_XmlScheduleres_pk");

        entity.ToTable("Gnl_XmlSchedulers", "dbo");

        entity.Property(e => e.CreatedDate).HasColumnType("datetime");
        entity.Property(e => e.LastWorkingTime).HasColumnType("datetime");

        entity.HasOne(d => d.Status).WithMany(p => p.GnlXmlSchedulers)
            .HasForeignKey(d => d.StatusId)
            .HasConstraintName("Gnl_XmlScheduleres_Sys_StatusTypes_Id_fk");

        entity.HasOne(d => d.Xml).WithMany(p => p.GnlXmlSchedulers)
            .HasForeignKey(d => d.XmlId)
            .HasConstraintName("Gnl_XmlScheduleres_Gnl_ProductXmls_Id_fk");
    }
}
