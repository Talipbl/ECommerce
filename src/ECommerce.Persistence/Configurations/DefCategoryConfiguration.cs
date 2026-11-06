using ECommerce.Category;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations;

public class DefCategoryConfiguration : IEntityTypeConfiguration<DefCategory>
{
    public void Configure(EntityTypeBuilder<DefCategory> entity)
    {
        entity.HasKey(e => e.Id).HasName("Categories_pk");

        entity.ToTable("Def_Categories", "dbo");

        entity.Property(e => e.CategoryName).HasMaxLength(100);
        entity.Property(e => e.Descriptipn).HasMaxLength(350);
        entity.Property(e => e.ImagePath).HasMaxLength(200);
    }
}
