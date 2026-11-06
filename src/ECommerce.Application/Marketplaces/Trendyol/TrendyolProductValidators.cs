using FluentValidation;
using Trendyol.Client.Products;

namespace ECommerce.Application.Marketplaces.Trendyol;

internal static class TrendyolRules
{
    public const int MaxItemsPerRequest = 1000;
    public const int MaxImages = 8;
    public const int MaxStock = 20000;
    public static readonly int[] VatRates = [0, 1, 10, 20];

    public static IRuleBuilderOptions<T, string> Barcode<T>(this IRuleBuilder<T, string> rule) =>
        rule.NotEmpty().MaximumLength(40)
            .Matches("^[A-Za-z0-9._-]+$").WithMessage("Barkod yalnızca harf, rakam ve '.', '-', '_' içerebilir.");

    public static IRuleBuilderOptions<T, IReadOnlyList<TrendyolImage>?> Images<T>(this IRuleBuilder<T, IReadOnlyList<TrendyolImage>?> rule) =>
        rule.Must(images => images is null || images.Count <= MaxImages).WithMessage($"En fazla {MaxImages} görsel gönderilebilir.")
            .Must(images => images is null || images.All(i => IsHttps(i.Url))).WithMessage("Görsel adresleri https olmalıdır.");

    public static IRuleBuilderOptions<T, IReadOnlyList<TItem>> Batch<T, TItem>(this IRuleBuilder<T, IReadOnlyList<TItem>> rule) =>
        rule.NotEmpty().Must(items => items.Count <= MaxItemsPerRequest).WithMessage($"Bir istekte en fazla {MaxItemsPerRequest} kalem gönderilebilir.");

    public static bool UniqueBarcodes(IEnumerable<string> barcodes) =>
        barcodes.GroupBy(b => b, StringComparer.Ordinal).All(g => g.Count() == 1);

    private static bool IsHttps(string url) =>
        Uri.TryCreate(url, UriKind.Absolute, out var uri) && uri.Scheme == Uri.UriSchemeHttps;
}

public class CreateTrendyolProductsRequestValidator : AbstractValidator<CreateTrendyolProductsRequest>
{
    public CreateTrendyolProductsRequestValidator()
    {
        RuleFor(x => x.Items).Batch()
            .Must(items => TrendyolRules.UniqueBarcodes(items.Select(i => i.Barcode))).WithMessage("Barkodlar istek içinde tekrar edemez.");

        RuleForEach(x => x.Items).ChildRules(item =>
        {
            item.RuleFor(i => i.Barcode).Barcode();
            item.RuleFor(i => i.Title).NotEmpty().MaximumLength(100);
            item.RuleFor(i => i.ProductMainId).NotEmpty().MaximumLength(40);
            item.RuleFor(i => i.Description).NotEmpty().MaximumLength(30000);
            item.RuleFor(i => i.BrandId).GreaterThan(0);
            item.RuleFor(i => i.CategoryId).GreaterThan(0);
            item.RuleFor(i => i.Quantity).InclusiveBetween(0, TrendyolRules.MaxStock);
            item.RuleFor(i => i.SalePrice).GreaterThan(0);
            item.RuleFor(i => i.ListPrice).GreaterThanOrEqualTo(i => i.SalePrice).WithMessage("Liste fiyatı satış fiyatından düşük olamaz.");
            item.RuleFor(i => i.VatRate).Must(v => TrendyolRules.VatRates.Contains(v)).WithMessage("KDV oranı 0, 1, 10 veya 20 olmalıdır.");
            item.RuleFor(i => (IReadOnlyList<TrendyolImage>?)i.Images).NotEmpty().Images().OverridePropertyName(nameof(CreateProductItem.Images));
            item.RuleFor(i => i.Attributes).NotNull();
            item.RuleFor(i => i.StockCode).MaximumLength(100);
            item.RuleFor(i => i.Origin).MaximumLength(2);
            item.RuleFor(i => i.LotNumber).MaximumLength(100);
        });
    }
}

public class UpdateTrendyolContentRequestValidator : AbstractValidator<UpdateTrendyolContentRequest>
{
    public UpdateTrendyolContentRequestValidator()
    {
        RuleFor(x => x.Items).Batch();
        RuleForEach(x => x.Items).ChildRules(item =>
        {
            item.RuleFor(i => i.ContentId).GreaterThan(0);
            item.RuleFor(i => i.Title).MaximumLength(100);
            item.RuleFor(i => i.Description).MaximumLength(30000);
            item.RuleFor(i => i.Images).Images();
            item.RuleFor(i => i)
                .Must(i => i.Title is not null || i.Description is not null || i.Images is not null || i.Attributes is not null)
                .WithMessage("Güncellenecek en az bir alan gönderilmelidir.");
        });
    }
}

public class UpdateUnapprovedTrendyolProductsRequestValidator : AbstractValidator<UpdateUnapprovedTrendyolProductsRequest>
{
    public UpdateUnapprovedTrendyolProductsRequestValidator()
    {
        RuleFor(x => x.Items).Batch()
            .Must(items => TrendyolRules.UniqueBarcodes(items.Select(i => i.Barcode))).WithMessage("Barkodlar istek içinde tekrar edemez.");
        RuleForEach(x => x.Items).ChildRules(item =>
        {
            item.RuleFor(i => i.Barcode).Barcode();
            item.RuleFor(i => i.Title).MaximumLength(100);
            item.RuleFor(i => i.Description).MaximumLength(30000);
            item.RuleFor(i => i.VatRate).Must(v => v is null || TrendyolRules.VatRates.Contains(v.Value)).WithMessage("KDV oranı 0, 1, 10 veya 20 olmalıdır.");
            item.RuleFor(i => i.Images).Images();
        });
    }
}

public class UpdatePriceInventoryRequestValidator : AbstractValidator<UpdatePriceInventoryRequest>
{
    public UpdatePriceInventoryRequestValidator()
    {
        RuleFor(x => x.Items).Batch()
            .Must(items => TrendyolRules.UniqueBarcodes(items.Select(i => i.Barcode))).WithMessage("Barkodlar istek içinde tekrar edemez.");
        RuleForEach(x => x.Items).ChildRules(item =>
        {
            item.RuleFor(i => i.Barcode).Barcode();
            item.RuleFor(i => i).Must(i => i.Quantity is not null || i.SalePrice is not null || i.ListPrice is not null)
                .WithMessage("Stok veya fiyat alanlarından en az biri gönderilmelidir.");
            item.RuleFor(i => i.Quantity).InclusiveBetween(0, TrendyolRules.MaxStock).When(i => i.Quantity is not null);
            item.RuleFor(i => i.SalePrice).GreaterThan(0).When(i => i.SalePrice is not null);
            item.RuleFor(i => i.ListPrice).GreaterThanOrEqualTo(i => i.SalePrice!.Value)
                .When(i => i.ListPrice is not null && i.SalePrice is not null)
                .WithMessage("Liste fiyatı satış fiyatından düşük olamaz.");
        });
    }
}

public class DeleteTrendyolProductsRequestValidator : AbstractValidator<DeleteTrendyolProductsRequest>
{
    public DeleteTrendyolProductsRequestValidator()
    {
        RuleFor(x => x.Barcodes).Batch()
            .Must(TrendyolRules.UniqueBarcodes).WithMessage("Barkodlar istek içinde tekrar edemez.");
        RuleForEach(x => x.Barcodes).Barcode();
    }
}
