using ECommerce.Core.Text;
using FluentValidation;

namespace ECommerce.Application.Catalog;

internal static class CatalogValidationRules
{
    public static readonly int[] VatRates = [0, 1, 10, 20];

    public static IRuleBuilderOptions<T, string?> OptionalSlug<T>(this IRuleBuilder<T, string?> rule) =>
        rule.Must(s => s is null || Slug.IsValid(s)).WithMessage("Adres (slug) yalnızca küçük harf, rakam ve tire içerebilir.");

    // Barkodlar pazaryerine de gönderileceği için Trendyol kuralları uygulanır.
    public static IRuleBuilderOptions<T, string> Barcode<T>(this IRuleBuilder<T, string> rule) =>
        rule.NotEmpty().MaximumLength(40).Matches("^[A-Za-z0-9._-]+$")
            .WithMessage("Barkod yalnızca harf, rakam ve '.', '-', '_' içerebilir.");

    public static void Price<T>(this AbstractValidator<T> validator, Func<T, decimal> price, Func<T, decimal?> listPrice, Func<T, int> stock)
    {
        validator.RuleFor(x => price(x)).GreaterThan(0).OverridePropertyName("Price");
        validator.RuleFor(x => listPrice(x)).Must((x, l) => l is null || l >= price(x))
            .WithMessage("Liste fiyatı satış fiyatından düşük olamaz.").OverridePropertyName("ListPrice");
        validator.RuleFor(x => stock(x)).GreaterThanOrEqualTo(0).OverridePropertyName("StockQuantity");
    }
}

public class SaveCategoryRequestValidator : AbstractValidator<SaveCategoryRequest>
{
    public SaveCategoryRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Slug).OptionalSlug();
        RuleFor(x => x.Description).MaximumLength(1000);
    }
}

public class SaveBrandRequestValidator : AbstractValidator<SaveBrandRequest>
{
    public SaveBrandRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Slug).OptionalSlug();
    }
}

public class VariantInputValidator : AbstractValidator<VariantInput>
{
    public VariantInputValidator()
    {
        RuleFor(x => x.Sku).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Barcode).Barcode();
        this.Price(x => x.Price, x => x.ListPrice, x => x.StockQuantity);
        RuleFor(x => x.Attributes).NotNull();
        RuleForEach(x => x.Attributes).ChildRules(a =>
        {
            a.RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            a.RuleFor(x => x.Value).NotEmpty().MaximumLength(100);
        });
    }
}

public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Slug).OptionalSlug();
        RuleFor(x => x.ProductCode).NotEmpty().MaximumLength(40);
        RuleFor(x => x.BrandId).GreaterThan(0);
        RuleFor(x => x.CategoryId).GreaterThan(0);
        RuleFor(x => x.VatRate).Must(v => CatalogValidationRules.VatRates.Contains(v)).WithMessage("KDV oranı 0, 1, 10 veya 20 olmalıdır.");
        RuleFor(x => x.Variants).NotEmpty().Must(v => v.Count <= 100).WithMessage("Bir ürüne en fazla 100 varyant eklenebilir.")
            .Must(v => v.Select(x => x.Barcode).Distinct().Count() == v.Count && v.Select(x => x.Sku).Distinct().Count() == v.Count)
            .WithMessage("Varyantlarda stok kodu ve barkod tekrar edemez.");
        RuleForEach(x => x.Variants).SetValidator(new VariantInputValidator());
    }
}

public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
{
    public UpdateProductRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Slug).NotEmpty().OptionalSlug();
        RuleFor(x => x.ProductCode).NotEmpty().MaximumLength(40);
        RuleFor(x => x.VatRate).Must(v => CatalogValidationRules.VatRates.Contains(v)).WithMessage("KDV oranı 0, 1, 10 veya 20 olmalıdır.");
    }
}

public class UpdateVariantRequestValidator : AbstractValidator<UpdateVariantRequest>
{
    public UpdateVariantRequestValidator()
    {
        this.Price(x => x.Price, x => x.ListPrice, x => x.StockQuantity);
        RuleFor(x => x.Attributes).NotNull();
    }
}
