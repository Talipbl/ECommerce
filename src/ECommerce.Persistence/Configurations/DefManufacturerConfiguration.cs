using ECommerce.Manufacturer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations;

public class DefManufacturerConfiguration : IEntityTypeConfiguration<DefManufacturer>
{
    public void Configure(EntityTypeBuilder<DefManufacturer> entity)
    {
        entity.HasKey(e => e.Id).HasName("Def_Manufacturers_pk");

        entity.ToTable("Def_Manufacturers", "dbo");

        entity.Property(e => e.ContacInfo).HasMaxLength(200);
        entity.Property(e => e.ManufacturersName).HasMaxLength(50);
    }
}
