using System;
using System.Collections.Generic;
using ECommerceNetCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceNetCore.Persistance.Context;

public partial class EcommerceNetCoreContext : DbContext
{
    public EcommerceNetCoreContext()
    {
    }

    public EcommerceNetCoreContext(DbContextOptions<EcommerceNetCoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DefAdmin> DefAdmins { get; set; }

    public virtual DbSet<DefBrand> DefBrands { get; set; }

    public virtual DbSet<DefCarrier> DefCarriers { get; set; }

    public virtual DbSet<DefCategory> DefCategories { get; set; }

    public virtual DbSet<DefDiscountCoupon> DefDiscountCoupons { get; set; }

    public virtual DbSet<DefManufacturer> DefManufacturers { get; set; }

    public virtual DbSet<DefSubCategory> DefSubCategories { get; set; }

    public virtual DbSet<GnlOrder> GnlOrders { get; set; }

    public virtual DbSet<GnlOrderPayment> GnlOrderPayments { get; set; }

    public virtual DbSet<GnlOrderProduct> GnlOrderProducts { get; set; }

    public virtual DbSet<GnlProduct> GnlProducts { get; set; }

    public virtual DbSet<GnlProductCategory> GnlProductCategories { get; set; }

    public virtual DbSet<GnlProductImage> GnlProductImages { get; set; }

    public virtual DbSet<GnlProductOption> GnlProductOptions { get; set; }

    public virtual DbSet<GnlProductPrice> GnlProductPrices { get; set; }

    public virtual DbSet<GnlProductXml> GnlProductXmls { get; set; }

    public virtual DbSet<GnlUser> GnlUsers { get; set; }

    public virtual DbSet<GnlUserAddress> GnlUserAddresses { get; set; }

    public virtual DbSet<GnlUserCoupon> GnlUserCoupons { get; set; }

    public virtual DbSet<GnlUserMailQueue> GnlUserMailQueues { get; set; }

    public virtual DbSet<GnlXmlSchedulere> GnlXmlScheduleres { get; set; }

    public virtual DbSet<GnlXmlSchedulereLog> GnlXmlSchedulereLogs { get; set; }

    public virtual DbSet<SysCurrency> SysCurrencies { get; set; }

    public virtual DbSet<SysMailType> SysMailTypes { get; set; }

    public virtual DbSet<SysPaymentType> SysPaymentTypes { get; set; }

    public virtual DbSet<SysStatusType> SysStatusTypes { get; set; }

    public virtual DbSet<SysUnitType> SysUnitTypes { get; set; }

    public virtual DbSet<SysVatRatio> SysVatRatios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=talipbulundu.com\\MSSQLSERVER2014;Database=ECommerceNetCore;User Id=root;Password=34Q1wt&n5; Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("root");

        modelBuilder.Entity<DefAdmin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Def_Admins_pk");

            entity.ToTable("Def_Admins", "dbo");

            entity.Property(e => e.FirstName).HasMaxLength(25);
            entity.Property(e => e.IsEnable2Fa).HasColumnName("IsEnable2FA");
            entity.Property(e => e.LastLoginDate).HasColumnType("datetime");
            entity.Property(e => e.LastName).HasMaxLength(25);
            entity.Property(e => e.MailAdress).HasMaxLength(75);
            entity.Property(e => e.OtpsetupCode)
                .HasMaxLength(250)
                .HasColumnName("OTPSetupCode");
            entity.Property(e => e.Password)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.RegisterDate).HasColumnType("datetime");
            entity.Property(e => e.UserName).HasMaxLength(30);
        });

        modelBuilder.Entity<DefBrand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Def_Brands_pk");

            entity.ToTable("Def_Brands", "dbo");

            entity.Property(e => e.BrandName).HasMaxLength(50);
        });

        modelBuilder.Entity<DefCarrier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Def_Carriers_pk");

            entity.ToTable("Def_Carriers", "dbo");

            entity.Property(e => e.CompanyAddress).HasMaxLength(100);
            entity.Property(e => e.CompanyName).HasMaxLength(50);
            entity.Property(e => e.CompanyPhone).HasMaxLength(15);
            entity.Property(e => e.ContractedPrice).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<DefCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Categories_pk");

            entity.ToTable("Def_Categories", "dbo");

            entity.Property(e => e.CategoryName).HasMaxLength(100);
            entity.Property(e => e.Descriptipn).HasMaxLength(350);
            entity.Property(e => e.ImagePath).HasMaxLength(200);
        });

        modelBuilder.Entity<DefDiscountCoupon>(entity =>
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
        });

        modelBuilder.Entity<DefManufacturer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Def_Manufacturers_pk");

            entity.ToTable("Def_Manufacturers", "dbo");

            entity.Property(e => e.ContacInfo).HasMaxLength(200);
            entity.Property(e => e.ManufacturersName).HasMaxLength(50);
        });

        modelBuilder.Entity<DefSubCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Def_SubCategories_pk");

            entity.ToTable("Def_SubCategories", "dbo");

            entity.Property(e => e.CategoryName).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.IsParent).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<GnlOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Gnl_Orders_pk");

            entity.ToTable("Gnl_Orders", "dbo");

            entity.Property(e => e.DiscountAmount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.OrderAmount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.OrderCode).HasMaxLength(20);
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.ShipAmount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.VatAmount).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.PaymentType).WithMany(p => p.GnlOrders)
                .HasForeignKey(d => d.PaymentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Gnl_Orders_Sys_PaymentTypes_Id_fk");

            entity.HasOne(d => d.Status).WithMany(p => p.GnlOrders)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("Gnl_Orders_Sys_StatusTypes_Id_fk");

            entity.HasOne(d => d.User).WithMany(p => p.GnlOrders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Gnl_Orders_Gnl_Users_Id_fk");
        });

        modelBuilder.Entity<GnlOrderPayment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Gnl_OrderPayments_pk");

            entity.ToTable("Gnl_OrderPayments", "dbo");

            entity.Property(e => e.Note).HasMaxLength(2000);
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Currencies).WithMany(p => p.GnlOrderPayments)
                .HasForeignKey(d => d.CurrenciesId)
                .HasConstraintName("Gnl_OrderPayments_Sys_Currencies_Id_fk");

            entity.HasOne(d => d.Order).WithMany(p => p.GnlOrderPayments)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Gnl_OrderPayments_Gnl_Orders_Id_fk");

            entity.HasOne(d => d.PaymentType).WithMany(p => p.GnlOrderPayments)
                .HasForeignKey(d => d.PaymentTypeId)
                .HasConstraintName("Gnl_OrderPayments_Sys_PaymentTypes_Id_fk");

            entity.HasOne(d => d.Status).WithMany(p => p.GnlOrderPayments)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Gnl_OrderPayments_Sys_StatusTypes_Id_fk");
        });

        modelBuilder.Entity<GnlOrderProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Gnl_OrderProducts_pk");

            entity.ToTable("Gnl_OrderProducts", "dbo");

            entity.Property(e => e.DiscountAmount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.VatAmount).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Order).WithMany(p => p.GnlOrderProducts)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Gnl_OrderProducts_Gnl_Orders_Id_fk");

            entity.HasOne(d => d.Product).WithMany(p => p.GnlOrderProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Gnl_OrderProducts_Gnl_Products_Id_fk");
        });

        modelBuilder.Entity<GnlProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Gnl_Products_pk");

            entity.ToTable("Gnl_Products", "dbo");

            entity.Property(e => e.AvailableDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.Ean)
                .HasMaxLength(20)
                .HasColumnName("EAN");
            entity.Property(e => e.IsAvailable)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.Isbn)
                .HasMaxLength(20)
                .HasColumnName("ISBN");
            entity.Property(e => e.Jan)
                .HasMaxLength(20)
                .HasColumnName("JAN");
            entity.Property(e => e.MinmumOrder).HasDefaultValueSql("((1))");
            entity.Property(e => e.Mpn)
                .HasMaxLength(20)
                .HasColumnName("MPN");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.SellerCode).HasMaxLength(20);
            entity.Property(e => e.SellerUrl).HasMaxLength(250);
            entity.Property(e => e.StatusId).HasDefaultValueSql("((1))");
            entity.Property(e => e.Upc)
                .HasMaxLength(20)
                .HasColumnName("UPC");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Brand).WithMany(p => p.GnlProducts)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Gnl_Products_Def_Brands_Id_fk");

            entity.HasOne(d => d.Category).WithMany(p => p.GnlProducts)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Gnl_Products_Def_Categories_Id_fk");

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.GnlProducts)
                .HasForeignKey(d => d.ManufacturerId)
                .HasConstraintName("Gnl_Products_Def_Manufacturers_Id_fk");

            entity.HasOne(d => d.Status).WithMany(p => p.GnlProducts)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Gnl_Products_Sys_StatusTypes_Id_fk");
        });

        modelBuilder.Entity<GnlProductCategory>(entity =>
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
        });

        modelBuilder.Entity<GnlProductImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Gnl_ProductImages_pk");

            entity.ToTable("Gnl_ProductImages", "dbo");

            entity.Property(e => e.ImageUrl).HasMaxLength(250);

            entity.HasOne(d => d.Option).WithMany(p => p.GnlProductImages)
                .HasForeignKey(d => d.OptionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Gnl_ProductImages_Gnl_ProductOptions_Id_fk");

            entity.HasOne(d => d.Product).WithMany(p => p.GnlProductImages)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Gnl_ProductImages_Gnl_Products_Id_fk");
        });

        modelBuilder.Entity<GnlProductOption>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Gnl_ProductOptions_pk");

            entity.ToTable("Gnl_ProductOptions", "dbo");

            entity.Property(e => e.Height).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Length).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.StatusId).HasDefaultValueSql("((1))");
            entity.Property(e => e.StockCode).HasMaxLength(15);
            entity.Property(e => e.UnitOfStock).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Weight).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Width).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.LengthType).WithMany(p => p.GnlProductOptionLengthTypes)
                .HasForeignKey(d => d.LengthTypeId)
                .HasConstraintName("Gnl_ProductOptions_Sys_UnitTypeId_Id_fk2");

            entity.HasOne(d => d.Product).WithMany(p => p.GnlProductOptions)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Gnl_ProductOptions_Gnl_Products_Id_fk");

            entity.HasOne(d => d.Status).WithMany(p => p.GnlProductOptions)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Gnl_ProductOptions_Sys_StatusTypes_Id_fk");

            entity.HasOne(d => d.UnitType).WithMany(p => p.GnlProductOptionUnitTypes)
                .HasForeignKey(d => d.UnitTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Gnl_ProductOptions_Sys_UnitTypeId_Id_fk");
        });

        modelBuilder.Entity<GnlProductPrice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Gnl_ProductPrices_pk");

            entity.ToTable("Gnl_ProductPrices", "dbo");

            entity.Property(e => e.DiscountExpireDate).HasColumnType("datetime");
            entity.Property(e => e.DiscountPrice).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.DiscountRatio).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.PurchasePrice).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.StatusId).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.Currency).WithMany(p => p.GnlProductPrices)
                .HasForeignKey(d => d.CurrencyId)
                .HasConstraintName("Gnl_ProductPrices_Sys_Currencies_Id_fk");

            entity.HasOne(d => d.Option).WithMany(p => p.GnlProductPrices)
                .HasForeignKey(d => d.OptionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Gnl_ProductPrices_Gnl_ProductOptions_Id_fk");

            entity.HasOne(d => d.Product).WithMany(p => p.GnlProductPrices)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Gnl_ProductPrices_Gnl_Products_Id_fk");

            entity.HasOne(d => d.Status).WithMany(p => p.GnlProductPrices)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Gnl_ProductPrices_Sys_StatusTypes_Id_fk");

            entity.HasOne(d => d.VatRatio).WithMany(p => p.GnlProductPrices)
                .HasForeignKey(d => d.VatRatioId)
                .HasConstraintName("Gnl_ProductPrices_Sys_VatRatios_Id_fk");
        });

        modelBuilder.Entity<GnlProductXml>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Gnl_ProductXmls_pk");

            entity.ToTable("Gnl_ProductXmls", "dbo");

            entity.Property(e => e.AvailableDateTag).HasMaxLength(25);
            entity.Property(e => e.BrandTag).HasMaxLength(25);
            entity.Property(e => e.CategoryNameTag).HasMaxLength(25);
            entity.Property(e => e.CategoryTreeSplitChar).HasMaxLength(25);
            entity.Property(e => e.CategoryTreeTag).HasMaxLength(25);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.CurrencyTag).HasMaxLength(25);
            entity.Property(e => e.DescriptionTag).HasMaxLength(25);
            entity.Property(e => e.Eantag)
                .HasMaxLength(25)
                .HasColumnName("EANTag");
            entity.Property(e => e.HeadTag).HasMaxLength(25);
            entity.Property(e => e.HeightTag).HasMaxLength(25);
            entity.Property(e => e.Isbntag)
                .HasMaxLength(25)
                .HasColumnName("ISBNTag");
            entity.Property(e => e.Jantag)
                .HasMaxLength(25)
                .HasColumnName("JANTag");
            entity.Property(e => e.LengthTag).HasMaxLength(25);
            entity.Property(e => e.LengthTypeTag).HasMaxLength(25);
            entity.Property(e => e.ManufacturerTag).HasMaxLength(25);
            entity.Property(e => e.MetaDescriptionTag).HasMaxLength(25);
            entity.Property(e => e.MetaKeywordsTag).HasMaxLength(25);
            entity.Property(e => e.MetaTitleTag).HasMaxLength(25);
            entity.Property(e => e.Mpntag)
                .HasMaxLength(25)
                .HasColumnName("MPNTag");
            entity.Property(e => e.OptionTag).HasMaxLength(25);
            entity.Property(e => e.OptionsTag).HasMaxLength(25);
            entity.Property(e => e.PictureTag).HasMaxLength(25);
            entity.Property(e => e.PicturesTag).HasMaxLength(25);
            entity.Property(e => e.PriceTag).HasMaxLength(25);
            entity.Property(e => e.ProductCodeTag).HasMaxLength(25);
            entity.Property(e => e.ProductTag).HasMaxLength(25);
            entity.Property(e => e.PurchasePriceTag).HasMaxLength(25);
            entity.Property(e => e.Skutag)
                .HasMaxLength(25)
                .HasColumnName("SKUTag");
            entity.Property(e => e.StatusTag).HasMaxLength(25);
            entity.Property(e => e.StockQuantityTag).HasMaxLength(25);
            entity.Property(e => e.StockUnitTag).HasMaxLength(25);
            entity.Property(e => e.TitleTag).HasMaxLength(25);
            entity.Property(e => e.Upctag)
                .HasMaxLength(25)
                .HasColumnName("UPCTag");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UrlTag).HasMaxLength(25);
            entity.Property(e => e.VatRatioTag).HasMaxLength(25);
            entity.Property(e => e.WeightTag).HasMaxLength(25);
            entity.Property(e => e.WidthTag).HasMaxLength(25);
            entity.Property(e => e.XmlLink).HasMaxLength(250);

            entity.HasOne(d => d.Status).WithMany(p => p.GnlProductXmls)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Gnl_ProductXmls_Sys_StatusTypes_Id_fk");
        });

        modelBuilder.Entity<GnlUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Gnl_Users_pk");

            entity.ToTable("Gnl_Users", "dbo");

            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.FixedPhoneNumber).HasMaxLength(15);
            entity.Property(e => e.Identity).HasMaxLength(11);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MailAddress).HasMaxLength(75);
            entity.Property(e => e.MobilePhoneNumber).HasMaxLength(15);
            entity.Property(e => e.PasswordHash).HasMaxLength(500);
            entity.Property(e => e.PasswordSalt).HasMaxLength(500);
            entity.Property(e => e.StatusId).HasDefaultValueSql("((1))");
            entity.Property(e => e.TaxNumber).HasMaxLength(10);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Status).WithMany(p => p.GnlUsers)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Gnl_Users_Sys_StatusTypes_Id_fk");
        });

        modelBuilder.Entity<GnlUserAddress>(entity =>
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
        });

        modelBuilder.Entity<GnlUserCoupon>(entity =>
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
        });

        modelBuilder.Entity<GnlUserMailQueue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Gnl_UserMailQueues_pk");

            entity.ToTable("Gnl_UserMailQueues", "dbo");

            entity.Property(e => e.Content).HasMaxLength(2000);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.MailAddress).HasMaxLength(75);
            entity.Property(e => e.NameSurname).HasMaxLength(100);
            entity.Property(e => e.SendDate).HasColumnType("datetime");

            entity.HasOne(d => d.MailType).WithMany(p => p.GnlUserMailQueues)
                .HasForeignKey(d => d.MailTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Gnl_UserMailQueues_Sys_MailTypes_Id_fk");

            entity.HasOne(d => d.User).WithMany(p => p.GnlUserMailQueues)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Gnl_UserMailQueues_Gnl_Users_Id_fk");
        });

        modelBuilder.Entity<GnlXmlSchedulere>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Gnl_XmlScheduleres_pk");

            entity.ToTable("Gnl_XmlScheduleres", "dbo");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.LastWorkingTime).HasColumnType("datetime");

            entity.HasOne(d => d.Status).WithMany(p => p.GnlXmlScheduleres)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("Gnl_XmlScheduleres_Sys_StatusTypes_Id_fk");

            entity.HasOne(d => d.Xml).WithMany(p => p.GnlXmlScheduleres)
                .HasForeignKey(d => d.XmlId)
                .HasConstraintName("Gnl_XmlScheduleres_Gnl_ProductXmls_Id_fk");
        });

        modelBuilder.Entity<GnlXmlSchedulereLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Gnl_XmlSchedulereLogs_pk");

            entity.ToTable("Gnl_XmlSchedulereLogs", "dbo");

            entity.Property(e => e.WorkedTime).HasColumnType("datetime");

            entity.HasOne(d => d.Schedulere).WithMany(p => p.GnlXmlSchedulereLogs)
                .HasForeignKey(d => d.SchedulereId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Gnl_XmlSchedulereLogs_Gnl_XmlScheduleres_Id_fk");

            entity.HasOne(d => d.Xml).WithMany(p => p.GnlXmlSchedulereLogs)
                .HasForeignKey(d => d.XmlId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Gnl_XmlSchedulereLogs_Gnl_ProductXmls_Id_fk");
        });

        modelBuilder.Entity<SysCurrency>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Sys_Currencies_pk");

            entity.ToTable("Sys_Currencies", "dbo");

            entity.Property(e => e.CurrencyCode).HasMaxLength(10);
            entity.Property(e => e.CurrencyName).HasMaxLength(25);
        });

        modelBuilder.Entity<SysMailType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Sys_MailTypes_pk");

            entity.ToTable("Sys_MailTypes", "dbo");

            entity.Property(e => e.MailTypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<SysPaymentType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Sys_PaymentTypes_pk");

            entity.ToTable("Sys_PaymentTypes", "dbo");

            entity.Property(e => e.PaymentName).HasMaxLength(25);
        });

        modelBuilder.Entity<SysStatusType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Sys_StatusTypes_pk");

            entity.ToTable("Sys_StatusTypes", "dbo");

            entity.Property(e => e.StatusName).HasMaxLength(25);
        });

        modelBuilder.Entity<SysUnitType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Sys_UnitTypeId_pk");

            entity.ToTable("Sys_UnitTypes", "dbo");

            entity.Property(e => e.TypeName).HasMaxLength(15);
        });

        modelBuilder.Entity<SysVatRatio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Sys_VatRatios_pk");

            entity.ToTable("Sys_VatRatios", "dbo");

            entity.Property(e => e.VatRatioValue).HasColumnType("decimal(18, 0)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
