using Asp.Versioning;
using ECommerce.API.Infrastructure;
using ECommerce.Application.Marketplaces.Trendyol;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers.Trendyol;

[ApiController]
[ApiVersion(1.0)]
[Route("api/v{version:apiVersion}/marketplaces/trendyol")]
[Tags("Trendyol - Entegrasyon")]
public class TrendyolIntegrationController(
    ITrendyolListingService listings,
    ITrendyolInventorySyncService inventory,
    ITrendyolOrderImportService orderImport) : ControllerBase
{
    [HttpGet("mappings/categories")]
    public async Task<IReadOnlyList<CategoryMappingDto>> ListCategoryMappings(CancellationToken cancellationToken) =>
        await listings.ListCategoryMappingsAsync(cancellationToken);

    [HttpPut("mappings/categories/{categoryId:int}")]
    public async Task<IActionResult> MapCategory(int categoryId, MapCategoryRequest request, CancellationToken cancellationToken) =>
        this.ToActionResult(await listings.MapCategoryAsync(categoryId, request, cancellationToken), Ok);

    [HttpGet("mappings/brands")]
    public async Task<IReadOnlyList<BrandMappingDto>> ListBrandMappings(CancellationToken cancellationToken) =>
        await listings.ListBrandMappingsAsync(cancellationToken);

    [HttpPut("mappings/brands/{brandId:int}")]
    public async Task<IActionResult> MapBrand(int brandId, MapBrandRequest request, CancellationToken cancellationToken) =>
        this.ToActionResult(await listings.MapBrandAsync(brandId, request, cancellationToken), Ok);

    [HttpGet("listings/{productId:int}")]
    public async Task<IActionResult> GetListing(int productId, CancellationToken cancellationToken) =>
        this.ToActionResult(await listings.GetAsync(productId, cancellationToken), Ok);

    [HttpPost("listings/{productId:int}")]
    [ProducesResponseType<ListingDto>(StatusCodes.Status202Accepted)]
    public async Task<IActionResult> Publish(int productId, PublishListingRequest request, CancellationToken cancellationToken) =>
        this.ToActionResult(await listings.PublishAsync(productId, request, cancellationToken), l => StatusCode(StatusCodes.Status202Accepted, l));

    /// <summary>Arka plan işlerini beklemeden elle tetikler.</summary>
    [HttpPost("sync/listings")]
    public async Task<IActionResult> SyncListings(CancellationToken cancellationToken) =>
        Ok(new { updated = await listings.RefreshStatusesAsync(cancellationToken) });

    [HttpPost("sync/inventory")]
    public async Task<IActionResult> SyncInventory(CancellationToken cancellationToken) =>
        Ok(new { processed = await inventory.SyncPendingAsync(cancellationToken) });

    [HttpPost("sync/orders")]
    public async Task<OrderImportSummary> SyncOrders(CancellationToken cancellationToken) =>
        await orderImport.ImportAsync(cancellationToken);
}
