using ECommerce.Carrier;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations;

public class DefCarrierConfiguration : IEntityTypeConfiguration<DefCarrier>
{
    public void Configure(EntityTypeBuilder<DefCarrier> entity)
    {
        entity.HasKey(e => e.Id).HasName("Def_Carriers_pk");

        entity.ToTable("Def_Carriers", "dbo");

        entity.Property(e => e.CompanyAddress).HasMaxLength(100);
        entity.Property(e => e.CompanyName).HasMaxLength(50);
        entity.Property(e => e.CompanyPhone).HasMaxLength(15);
        entity.Property(e => e.ContractedPrice).HasColumnType("decimal(18, 0)");
        entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
    }
}
