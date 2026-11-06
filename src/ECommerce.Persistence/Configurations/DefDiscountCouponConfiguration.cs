using ECommerce.DiscountCoupon;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations;

public class DefDiscountCouponConfiguration : IEntityTypeConfiguration<DefDiscountCoupon>
{
    public void Configure(EntityTypeBuilder<DefDiscountCoupon> entity)
    {
        entity.HasKey(e => e.Id).HasName("Def_DiscountCoupons_pk");

        entity.ToTable("Def_DiscountCoupons", "dbo");

        entity.Property(e => e.CouponCode).HasMaxLength(15);
        entity.Property(e => e.CouponName).HasMaxLength(30);
        entity.Property(e => e.CreatedDate).HasColumnType("datetime");
        entity.Property(e => e.DiscountRate).HasColumnType("decimal(18, 0)");
        entity.Property(e => e.MinumumOrder).HasColumnType("decimal(18, 0)");

        entity.HasOne(d => d.Category).WithMany(p => p.DefDiscountCoupons)
            .HasForeignKey(d => d.CategoryId)
            .HasConstraintName("Def_DiscountCoupons_Def_Categories_Id_fk");

        entity.HasOne(d => d.Product).WithMany(p => p.DefDiscountCoupons)
            .HasForeignKey(d => d.ProductId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Def_DiscountCoupons_Gnl_Products_Id_fk");

        entity.HasOne(d => d.SubCategory).WithMany(p => p.DefDiscountCoupons)
            .HasForeignKey(d => d.SubCategoryId)
            .HasConstraintName("Def_DiscountCoupons_Def_SubCategories_Id_fk");
    }
}
