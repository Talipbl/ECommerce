using ECommerce.Catalog;
using ECommerce.Marketplaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace ECommerce.Persistence.Configurations;

internal static class JsonColumn
{
    public static PropertyBuilder<List<T>> AsJson<TEntity, T>(this EntityTypeBuilder<TEntity> entity, string field, string column) where TEntity : class =>
        entity.Property<List<T>>(field)
            .HasColumnName(column)
            .HasColumnType("nvarchar(max)")
            .HasConversion(
                v => JsonSerializer.Serialize(v, JsonSerializerOptions.Web),
                v => JsonSerializer.Deserialize<List<T>>(v, JsonSerializerOptions.Web) ?? new List<T>(),
                new ValueComparer<List<T>>(
                    (a, b) => JsonSerializer.Serialize(a, JsonSerializerOptions.Web) == JsonSerializer.Serialize(b, JsonSerializerOptions.Web),
                    v => JsonSerializer.Serialize(v, JsonSerializerOptions.Web).GetHashCode(),
                    v => v.ToList()));
}

public class MarketplaceCategoryMappingConfiguration : IEntityTypeConfiguration<MarketplaceCategoryMapping>
{
    public void Configure(EntityTypeBuilder<MarketplaceCategoryMapping> entity)
    {
        entity.ToTable("Marketplace_CategoryMappings", "dbo");
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Marketplace).HasMaxLength(30).IsRequired();
        entity.Property(e => e.ExternalCategoryName).HasMaxLength(300);
        entity.HasIndex(e => new { e.Marketplace, e.CategoryId }).IsUnique().HasFilter(CatalogTables.NotDeleted);
        entity.HasOne<Category>().WithMany().HasForeignKey(e => e.CategoryId).OnDelete(DeleteBehavior.Cascade);
    }
}

public class MarketplaceBrandMappingConfiguration : IEntityTypeConfiguration<MarketplaceBrandMapping>
{
    public void Configure(EntityTypeBuilder<MarketplaceBrandMapping> entity)
    {
        entity.ToTable("Marketplace_BrandMappings", "dbo");
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Marketplace).HasMaxLength(30).IsRequired();
        entity.Property(e => e.ExternalBrandName).HasMaxLength(200);
        entity.HasIndex(e => new { e.Marketplace, e.BrandId }).IsUnique().HasFilter(CatalogTables.NotDeleted);
        entity.HasOne<Brand>().WithMany().HasForeignKey(e => e.BrandId).OnDelete(DeleteBehavior.Cascade);
    }
}

public class MarketplaceListingConfiguration : IEntityTypeConfiguration<MarketplaceListing>
{
    public void Configure(EntityTypeBuilder<MarketplaceListing> entity)
    {
        entity.ToTable("Marketplace_Listings", "dbo");
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Marketplace).HasMaxLength(30).IsRequired();
        entity.Property(e => e.Status).HasConversion<string>().HasMaxLength(20);
        entity.Property(e => e.LastBatchRequestId).HasMaxLength(100);
        entity.Property(e => e.StatusMessage).HasMaxLength(2000);
        entity.HasIndex(e => new { e.Marketplace, e.ProductId }).IsUnique().HasFilter(CatalogTables.NotDeleted);
        entity.HasIndex(e => e.LastBatchRequestId);
        entity.HasOne<Product>().WithMany().HasForeignKey(e => e.ProductId).OnDelete(DeleteBehavior.Cascade);

        entity.Ignore(e => e.ProductAttributes);
        entity.Ignore(e => e.VariantAttributes);
        entity.AsJson<MarketplaceListing, ListingAttribute>("_productAttributes", "ProductAttributes");
        entity.AsJson<MarketplaceListing, VariantListingAttributes>("_variantAttributes", "VariantAttributes");
    }
}

public class MarketplaceInventoryChangeConfiguration : IEntityTypeConfiguration<MarketplaceInventoryChange>
{
    public void Configure(EntityTypeBuilder<MarketplaceInventoryChange> entity)
    {
        entity.ToTable("Marketplace_InventoryOutbox", "dbo");
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Error).HasMaxLength(2000);
        entity.HasIndex(e => e.ProcessedAt);
    }
}
