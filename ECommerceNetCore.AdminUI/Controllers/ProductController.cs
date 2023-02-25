using ECommerceNetCore.AdminUI.Helpers;
using ECommerceNetCore.Application.Aspects;
using ECommerceNetCore.Application.DataTransferObjects;
using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Application.Results;
using ECommerceNetCore.Application.Validators;
using ECommerceNetCore.Domain.Common;
using ECommerceNetCore.Domain.Entities;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace ECommerceNetCore.AdminUI.Controllers
{
    [Route("products")]
    [Route("urunler")]
    public class ProductController : Controller
    {
        ICategoryService _categorySrv;
        IProductService _productSrv;
        public ProductController(ICategoryService categorySrv, IProductService productSrv)
        {
            _categorySrv = categorySrv;
            _productSrv = productSrv;
        }

        [HttpGet]
        [Route("yeni-urun")]
        public IActionResult AddProduct()
        {
            var categories = _categorySrv.GetCategories().Data;
            return View(categories);
        }

        [HttpPost]
        [Route("add")]
        public JsonResult AddProduct([FromBody] ProductMasterModelDto masterProduct)
        {
            ProductMasterModelValidator validator = new ProductMasterModelValidator();
            var validationResult = validator.Validate(masterProduct);

            if (!validationResult.IsValid)
            {
                return Json(new ErrorDataResult<List<ValidationFailure>>(validationResult.Errors, ValidationConst.ValidationFailed));
            }

            GnlProduct product = new GnlProduct()
            {
                Name = masterProduct.Name,
                Description = masterProduct.Description,
                BrandId = masterProduct.BrandId,
                ManufacturerId = masterProduct.ManufacturerId,
                CategoryId = masterProduct.CategoryId,
                Ean = masterProduct.Ean,
                Jan = masterProduct.Ean,
                Isbn = masterProduct.Isbn,
                Upc = masterProduct.Upc,
                Mpn = masterProduct.Mpn,
                MinmumOrder = masterProduct.MinmumOrder,
                SellerCode = masterProduct.SellerCode,
                SellerUrl = masterProduct.SellerUrl,
                StockCode = masterProduct.StockCode,
                StatusId = masterProduct.StatusId,
                CreatedDate = DateTime.Now
            };

            var addedProduct = _productSrv.AddProduct(product);

            //masterProduct.ProductOptions.ForEach(option =>
            //{
            //    GnlProductOption productOption = new GnlProductOption()
            //    {
            //        ProductId = addedProduct.Data.Id,
            //        OptionName = option.OptionName,
            //        UnitTypeId = option.UnitTypeId,
            //        UnitOfStock = option.UnitOfStock,
            //        LengthTypeId = option.LengthTypeId,
            //        Width = option.Width,
            //        Height = option.Height,
            //        Length = option.Length,
            //        Weight = option.Weight,
            //        IsAvailable = option.IsAvailable,
            //        AvailableDate = option.AvailableDate,
            //        StatusId = option.StatusId,
            //        StockCode = option.StockCode
            //    };

            //    var addedOption = _productSrv.AddProductOption(productOption);

            //    GnlProductPrice productPrice = new GnlProductPrice()
            //    {
            //        OptionId = addedOption.Data.Id,
            //        ProductId = addedProduct.Data.Id,
            //        CurrencyId = option.CurrencyId,
            //        Price = option.Price,
            //        PurchasePrice = option.PurchasePrice,
            //        DiscountPrice = option.DiscountPrice,
            //        DiscountRatio = option.DiscountRatio,
            //        DiscountExpireDate = option.DiscountExpireDate,
            //        VatRatioId = option.VatRatioId,
            //        IsSale = option.IsSale,
            //        StatusId = option.StatusId
            //    };

            //    _productSrv.AddProductPrice(productPrice);
            //});

            return Json(new SuccessResult(ProductConst.ProductAdded));
        }

        [HttpGet]
        [Route("option/partial")]
        public async Task<JsonResult> GetOptionPartial()
        {
            var partialView = await this.RenderViewAsync("Partials/ProductOptionPartial");
            return Json(partialView);
        }

        [HttpGet]
        [Route("subcategory/partial")]
        public async Task<JsonResult> GetSubCategoryPartial(int parentId)
        {
            var subCategories = _categorySrv.GetSubCategories(parentId);
            var partilaView = await this.RenderViewAsync("Partials/SubCategoryPartial", subCategories.Data, true);
            return Json(partilaView);
        }

    }
}
