using ECommerce.Admin;
using ECommerce.Brand;
using ECommerce.Carrier;
using ECommerce.Category;
using ECommerce.DiscountCoupon;
using ECommerce.Manufacturer;
using ECommerce.Order;
using ECommerce.Product;
using ECommerce.Systems;
using ECommerce.User;
using ECommerce.Xml;
using ECommerce.Core.Domain;
using ECommerce.Core.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ECommerce.Persistence;

public class ECommerceContext(DbContextOptions<ECommerceContext> options) : DbContext(options), IUnitOfWork
{
    public DbSet<DefAdmin> DefAdmins => Set<DefAdmin>();

    public DbSet<DefBrand> DefBrands => Set<DefBrand>();

    public DbSet<DefCarrier> DefCarriers => Set<DefCarrier>();

    public DbSet<DefCategory> DefCategories => Set<DefCategory>();

    public DbSet<DefDiscountCoupon> DefDiscountCoupons => Set<DefDiscountCoupon>();

    public DbSet<DefManufacturer> DefManufacturers => Set<DefManufacturer>();

    public DbSet<DefSubCategory> DefSubCategories => Set<DefSubCategory>();

    public DbSet<GnlOrder> GnlOrders => Set<GnlOrder>();

    public DbSet<GnlOrderPayment> GnlOrderPayments => Set<GnlOrderPayment>();

    public DbSet<GnlOrderProduct> GnlOrderProducts => Set<GnlOrderProduct>();

    public DbSet<GnlProduct> GnlProducts => Set<GnlProduct>();

    public DbSet<GnlProductCategory> GnlProductCategories => Set<GnlProductCategory>();

    public DbSet<GnlProductImage> GnlProductImages => Set<GnlProductImage>();

    public DbSet<GnlProductOption> GnlProductOptions => Set<GnlProductOption>();

    public DbSet<GnlProductPrice> GnlProductPrices => Set<GnlProductPrice>();

    public DbSet<GnlProductXml> GnlProductXmls => Set<GnlProductXml>();

    public DbSet<GnlUser> GnlUsers => Set<GnlUser>();

    public DbSet<GnlUserAddress> GnlUserAddresses => Set<GnlUserAddress>();

    public DbSet<GnlUserCoupon> GnlUserCoupons => Set<GnlUserCoupon>();

    public DbSet<GnlUserMailQueue> GnlUserMailQueues => Set<GnlUserMailQueue>();

    public DbSet<GnlXmlScheduler> GnlXmlSchedulers => Set<GnlXmlScheduler>();

    public DbSet<GnlXmlSchedulerLog> GnlXmlSchedulerLogs => Set<GnlXmlSchedulerLog>();

    public DbSet<SysCurrency> SysCurrencies => Set<SysCurrency>();

    public DbSet<SysErrorLog> SysErrorLogs => Set<SysErrorLog>();

    public DbSet<SysMailType> SysMailTypes => Set<SysMailType>();

    public DbSet<SysPaymentType> SysPaymentTypes => Set<SysPaymentType>();

    public DbSet<SysStatusType> SysStatusTypes => Set<SysStatusType>();

    public DbSet<SysUnitType> SysUnitTypes => Set<SysUnitType>();

    public DbSet<SysVatRatio> SysVatRatios => Set<SysVatRatio>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("root");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ECommerceContext).Assembly);

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(IAuditableEntity).IsAssignableFrom(entityType.ClrType))
                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(NotDeletedFilter(entityType.ClrType));
        }
    }

    private static LambdaExpression NotDeletedFilter(Type entityType)
    {
        var parameter = Expression.Parameter(entityType, "e");
        var deletedDate = Expression.Property(parameter, nameof(IAuditableEntity.DeletedDate));
        var isNotDeleted = Expression.Equal(deletedDate, Expression.Constant(null, typeof(DateTime?)));
        return Expression.Lambda(isNotDeleted, parameter);
    }
}
