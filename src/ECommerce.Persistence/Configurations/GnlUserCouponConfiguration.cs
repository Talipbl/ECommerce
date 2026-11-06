using ECommerce.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations;

public class GnlUserCouponConfiguration : IEntityTypeConfiguration<GnlUserCoupon>
{
    public void Configure(EntityTypeBuilder<GnlUserCoupon> entity)
    {
        entity.HasKey(e => e.Id).HasName("Gnl_UserCoupons_pk");

        entity.ToTable("Gnl_UserCoupons", "dbo");

        entity.Property(e => e.CreatedDate).HasColumnType("datetime");
        entity.Property(e => e.ExpireDate).HasColumnType("datetime");
        entity.Property(e => e.IsUsed).HasDefaultValueSql("((0))");
        entity.Property(e => e.UsedDate).HasColumnType("datetime");

        entity.HasOne(d => d.Coupon).WithMany(p => p.GnlUserCoupons)
            .HasForeignKey(d => d.CouponId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Gnl_UserCoupons_Def_DiscountCoupons_Id_fk");

        entity.HasOne(d => d.User).WithMany(p => p.GnlUserCoupons)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Gnl_UserCoupons_Gnl_Users_Id_fk");
    }
}
