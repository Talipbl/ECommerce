using ECommerce.Category;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations;

public class DefSubCategoryConfiguration : IEntityTypeConfiguration<DefSubCategory>
{
    public void Configure(EntityTypeBuilder<DefSubCategory> entity)
    {
        entity.HasKey(e => e.Id).HasName("Def_SubCategories_pk");

        entity.ToTable("Def_SubCategories", "dbo");

        entity.Property(e => e.CategoryName).HasMaxLength(100);
        entity.Property(e => e.Description).HasMaxLength(200);
        entity.Property(e => e.IsParent).HasDefaultValueSql("((0))");
    }
}
