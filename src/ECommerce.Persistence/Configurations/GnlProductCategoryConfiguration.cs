using ECommerce.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations;

public class GnlProductCategoryConfiguration : IEntityTypeConfiguration<GnlProductCategory>
{
    public void Configure(EntityTypeBuilder<GnlProductCategory> entity)
    {
        entity.HasKey(e => e.Id).HasName("Gnl_ProductCategories_pk");

        entity.ToTable("Gnl_ProductCategories", "dbo");

        entity.HasOne(d => d.Product).WithMany(p => p.GnlProductCategories)
            .HasForeignKey(d => d.ProductId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Gnl_ProductCategories_Gnl_Products_Id_fk");

        entity.HasOne(d => d.SubCategory).WithMany(p => p.GnlProductCategories)
            .HasForeignKey(d => d.SubCategoryId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Gnl_ProductCategories_Def_SubCategories_Id_fk");
    }
}
