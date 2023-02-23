using ECommerceNetCore.Application.DataTransferObjects;
using ECommerceNetCore.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Application.Validators
{
    public class ProductMasterModelValidator : AbstractValidator<ProductMasterModelDto>
    {
        public ProductMasterModelValidator()
        {
            RuleFor(x => x.Name).Must(x => x.Length > 10 && x.Length < 100).WithMessage("Ürün adı 10 ile 100 karakter arasında olmalıdır.");
            RuleFor(x => x.Description).Must(x => x.Length > 100 && x.Length < 2000).WithMessage("Ürün açıklaması 100 ile 2000 karakter arasında olmalıdır.");
            RuleFor(x => x.BrandId).Must(x => x > 0).WithMessage("Ürün markası boş geçilemez.");
            RuleFor(x => x.MinmumOrder).Must(x => x > 0).WithMessage("Minimum sipariş adedi 0'dan büyük olmalıdır.");
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
                foreach (var option in options)
                {
                    var index = options.FindIndex(x => x.OptionName == option.OptionName) + 1;
                    if (BeNotNullAndLessThan(option.OptionName, 50))
                        context.AddFailure(index + "numaralı varyasyonun adı boş veya 15 karakterden fazla olamaz.");
                    if (BeNullOrLessThan(option.StockCode, 15))
                        context.AddFailure(index + "numaralı varyasyonun stok kodu 15 karakterden fazla olamaz.");
                    if (option.ProductPrice.Price !> 0.00M)
                        context.AddFailure(index + "numaralı varyasyonun fiyatı 0 olamaz.");
                }
            });

        }
        private bool BeNullOrLessThan(string? arg, int length)
        {
            if (arg is not null)
                return arg.Length <= length ? true : false;
            return true;
        }
        private bool BeNotNullAndLessThan(string? arg, int length)
        {
            if (arg is not null)
                return arg.Length <= length ? true : false;
            return false;
        }
        private bool BeNotNullAndInRange(string? arg, int min, int max)
        {
            return false;//Aralık kontrolü yapılacak.
        }
    }
}
