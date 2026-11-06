using ECommerce.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations;

public class GnlUserConfiguration : IEntityTypeConfiguration<GnlUser>
{
    public void Configure(EntityTypeBuilder<GnlUser> entity)
    {
        entity.HasKey(e => e.Id).HasName("Gnl_Users_pk");

        entity.ToTable("Gnl_Users", "dbo");

        entity.Property(e => e.City).HasMaxLength(50);
        entity.Property(e => e.Country).HasMaxLength(50);
        entity.Property(e => e.CreatedDate).HasColumnType("datetime");
        entity.Property(e => e.FirstName).HasMaxLength(50);
        entity.Property(e => e.FixedPhoneNumber).HasMaxLength(15);
        entity.Property(e => e.Identity).HasMaxLength(11);
        entity.Property(e => e.LastName).HasMaxLength(50);
        entity.Property(e => e.MailAddress).HasMaxLength(75);
        entity.Property(e => e.MobilePhoneNumber).HasMaxLength(15);
        entity.Property(e => e.PasswordHash).HasMaxLength(500);
        entity.Property(e => e.PasswordSalt).HasMaxLength(500);
        entity.Property(e => e.StatusId).HasDefaultValueSql("((1))");
        entity.Property(e => e.TaxNumber).HasMaxLength(10);
        entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

        entity.HasOne(d => d.Status).WithMany(p => p.GnlUsers)
            .HasForeignKey(d => d.StatusId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Gnl_Users_Sys_StatusTypes_Id_fk");
    }
}
