using Castle.Core.Internal;
using ECommerce.Application.DataTransferObjects.Products;
using FluentValidation;
using System.Globalization;

namespace ECommerce.Product
{
    public class ProductMasterModelValidator : AbstractValidator<ProductMasterModelDto>
    {
        public ProductMasterModelValidator()
        {
            RuleFor(x => x.Name).Must(x => BeNotNullAndInRange(x, 10, 100)).WithMessage("Ürün adı 10 ile 100 karakter arasında olmalıdır.");
            RuleFor(x => x.Description).Must(x => BeNotNullAndInRange(x, 100, 20000)).WithMessage("Ürün açıklaması 100 ile 20000 karakter arasında olmalıdır.");
            RuleFor(x => x.BrandId).Must(x => x > 0).WithMessage("Ürün markası boş geçilemez.");
            RuleFor(x => x.MinimumOrder).Must(x => x > 0).WithMessage("Minimum sipariş adedi 0'dan büyük olmalıdır.");
            RuleFor(x => x.CategoryId).Must(x => x > 0).WithMessage("Ana kategori boş geçilemez");
            RuleFor(x => x.SubCategoryId).Must(x => x > 0).WithMessage("Alt kategori boş geçilemez");
            RuleFor(x => x.Upc).Must(x => BeNullOrLessThan(x, 20)).WithMessage("UPC 20 karakterden fazla olamaz.");
            RuleFor(x => x.Ean).Must(x => BeNullOrLessThan(x, 20)).WithMessage("EAN 20 karakterden fazla olamaz.");
            RuleFor(x => x.Jan).Must(x => BeNullOrLessThan(x, 20)).WithMessage("JAN 20 karakterden fazla olamaz.");
            RuleFor(x => x.Isbn).Must(x => BeNullOrLessThan(x, 20)).WithMessage("ISBN 20 karakterden fazla olamaz.");
            RuleFor(x => x.Mpn).Must(x => BeNullOrLessThan(x, 20)).WithMessage("MPN 20 karakterden fazla olamaz.");
            RuleFor(x => x.StockCode).Must(x => BeNullOrLessThan(x, 15)).WithMessage("Ürün stok kodu 15 karakterden fazla olamaz.");

            RuleFor(x => x.ProductOptions).Custom((options, context) =>
            {
                if (options is not null)
                {
                    var index = 0;
                    foreach (var option in options)
                    {
                        index++;
                        if (!BeNotNullAndInRange(option.OptionName, 2, 200))
                            context.AddFailure(index + ". varyasyonun adı boş veya 15 karakterden fazla olamaz.");
                        if (!BeNullOrLessThan(option.StockCode, 15))
                            context.AddFailure(index + ". varyasyonun stok kodu 15 karakterden fazla olamaz.");
                        if (option.Price == 0.00M)
                            context.AddFailure(index + ". varyasyonun fiyatı 0 olamaz.");

                        if (option.IsSale)
                        {
                            if (!DateTimeNotNullAndGreaterThanToday(option.DiscountExpireDate))
                                context.AddFailure(index + ". varyasyonun indirim bitiş tarihi bugünden küçük olamaz.");
                        }

                        if (!option.IsAvailable)
                        {
                            if (!DateTimeNotNullAndGreaterThanToday(option.AvailableDate))
                                context.AddFailure(index + ". varyasyonun stoğa giriş tarihi bugünden küçük olamaz.");
                        }

                        if (option.ProductImages.IsNullOrEmpty())
                        {
                            context.AddFailure(index + ". varyasyon için görsel eklemelisiniz.");
                        }

                    }
                }
                else context.AddFailure("En az 1 adet ürün seçeneği olmalıdır.");
            });

        }
        private bool BeNullOrLessThan(string? arg, int length)
        {
            if (arg is not null)
                return arg.Length <= length;
            return true;
        }
        private bool BeNotNullAndLessThan(string? arg, int length)
        {
            if (arg is not null)
                return arg.Length <= length;
            return false;
        }
        private bool BeNotNullAndInRange(string? arg, int min, int max)
        {
            if (arg is not null)
                return arg.Length >= min && arg.Length <= max;
            return false;
        }
        private bool DateTimeNotNullAndGreaterThanToday(string arg)
        {
            if (arg is null)
                return false;

            DateTime parsedDatetime;
            if (!DateTime.TryParseExact(arg, "dd/MM/yyyy HH:mm", null, DateTimeStyles.None, out parsedDatetime))
                return false;

            if (parsedDatetime < DateTime.Now)
                return false;

            return true;
        }
    }
}
