using ECommerce.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations;

public class GnlUserAddressConfiguration : IEntityTypeConfiguration<GnlUserAddress>
{
    public void Configure(EntityTypeBuilder<GnlUserAddress> entity)
    {
        entity
            .HasNoKey()
            .ToTable("Gnl_UserAddress", "dbo");

        entity.Property(e => e.Address).HasMaxLength(200);
        entity.Property(e => e.City).HasMaxLength(30);
        entity.Property(e => e.Country).HasMaxLength(30);
        entity.Property(e => e.FixedPhoneNumber).HasMaxLength(15);
        entity.Property(e => e.FullName).HasMaxLength(100);
        entity.Property(e => e.Id).ValueGeneratedOnAdd();
        entity.Property(e => e.Identity).HasMaxLength(11);
        entity.Property(e => e.IsDefault).HasDefaultValueSql("((1))");
        entity.Property(e => e.MobilePhoneNumber).HasMaxLength(15);
        entity.Property(e => e.TaxNumber).HasMaxLength(10);
        entity.Property(e => e.ZipCode).HasMaxLength(10);
    }
}
