using ECommerce.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations;

public class GnlUserMailQueueConfiguration : IEntityTypeConfiguration<GnlUserMailQueue>
{
    public void Configure(EntityTypeBuilder<GnlUserMailQueue> entity)
    {
        entity.HasKey(e => e.Id).HasName("Gnl_UserMailQueues_pk");

        entity.ToTable("Gnl_UserMailQueues", "dbo");

        entity.Property(e => e.Content).HasMaxLength(2000);
        entity.Property(e => e.CreatedDate).HasColumnType("datetime");
        entity.Property(e => e.MailAddress).HasMaxLength(75);
        entity.Property(e => e.NameSurname).HasMaxLength(100);
        entity.Property(e => e.SendDate).HasColumnType("datetime");

        entity.HasOne(d => d.MailType).WithMany(p => p.GnlUserMailQueues)
            .HasForeignKey(d => d.MailTypeId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Gnl_UserMailQueues_Sys_MailTypes_Id_fk");

        entity.HasOne(d => d.User).WithMany(p => p.GnlUserMailQueues)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Gnl_UserMailQueues_Gnl_Users_Id_fk");
    }
}
