using ECommerce.Brand;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations;

public class DefBrandConfiguration : IEntityTypeConfiguration<DefBrand>
{
    public void Configure(EntityTypeBuilder<DefBrand> entity)
    {
        entity.HasKey(e => e.Id).HasName("Def_Brands_pk");

        entity.ToTable("Def_Brands", "dbo");

        entity.Property(e => e.BrandName).HasMaxLength(50);
    }
}
