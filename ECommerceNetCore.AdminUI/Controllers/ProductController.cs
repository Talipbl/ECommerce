using ECommerceNetCore.AdminUI.Helpers;
using ECommerceNetCore.Application.Aspects;
using ECommerceNetCore.Application.DataTransferObjects;
using ECommerceNetCore.Application.Helpers;
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
using System.Globalization;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ECommerceNetCore.AdminUI.Controllers
{
    [Route("products")]
    [Route("urunler")]
    public class ProductController : Controller
    {
        ICategoryService _categorySrv;
        IProductService _productSrv;
        IFileHelper _fileHelper;
        public ProductController(ICategoryService categorySrv, IProductService productSrv, IFileHelper fileHelper)
        {
            _categorySrv = categorySrv;
            _productSrv = productSrv;
            _fileHelper = fileHelper;
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
        public JsonResult AddProductAsync([FromBody] ProductMasterModelDto masterProduct)
        {
            ProductMasterModelValidator validator = new ProductMasterModelValidator();//Product ManufacturerId hatası var.
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
                MinmumOrder = masterProduct.MinimumOrder,
                SellerCode = masterProduct.SellerCode,
                SellerUrl = masterProduct.SellerUrl,
                StockCode = masterProduct.StockCode,
                StatusId = masterProduct.StatusId,
                CreatedDate = DateTime.Now
            };

            var addedProduct = _productSrv.AddProduct(product);

            GnlProductCategory category = new GnlProductCategory()
            {
                ProductId = addedProduct.Data.Id,
                SubCategoryId = masterProduct.SubCategoryId,
            };

            //var addedCategory = _productSrv.AddProductCategory(category);

            masterProduct.ProductOptions.ForEach(async option =>
            {
                DateTime parsedDatetime;
                DateTime.TryParseExact(option.AvailableDate, "dd/MM/yyyy HH:mm", null, DateTimeStyles.None, out parsedDatetime);

                GnlProductOption productOption = new GnlProductOption()
                {
                    ProductId = addedProduct.Data.Id,
                    OptionName = option.OptionName,
                    UnitTypeId = option.UnitTypeId,
                    UnitOfStock = option.UnitOfStock,
                    LengthTypeId = option.LengthTypeId,
                    Width = option.Width,
                    Height = option.Height,
                    Length = option.Length,
                    Weight = option.Weight,
                    IsAvailable = option.IsAvailable,
                    AvailableDate = parsedDatetime,
                    StatusId = option.StatusId,
                    StockCode = option.StockCode
                };

                var addedOption = _productSrv.AddProductOption(productOption);

                DateTime.TryParseExact(option.DiscountExpireDate, "dd/MM/yyyy HH:mm", null, DateTimeStyles.None, out parsedDatetime);
                GnlProductPrice productPrice = new GnlProductPrice()
                {
                    OptionId = addedOption.Data.Id,
                    ProductId = addedProduct.Data.Id,
                    CurrencyId = option.CurrencyId,
                    Price = option.Price,
                    PurchasePrice = option.PurchasePrice,
                    DiscountPrice = option.DiscountPrice,
                    DiscountRatio = option.DiscountRatio,
                    DiscountExpireDate = parsedDatetime,
                    VatRatioId = option.VatRatioId,
                    IsSale = option.IsSale,
                    StatusId = option.StatusId
                };

                _productSrv.AddProductPrice(productPrice);

                foreach (var image in option.ProductImages)
                {
                    if (image is null)
                        continue;

                    var base64String = image;
                    var data = base64String.Split(',');
                    var dataInfo = data[0];
                    var fileName = dataInfo.Split(';')[0];

                    byte[] bytes = Convert.FromBase64String(data[1]);

                    var uploadedImage = await _fileHelper.ImageUpload(bytes, fileName);
                    if (uploadedImage.Success)
                    {
                        GnlProductImage newImage = new GnlProductImage()
                        {
                            ProductId = addedProduct.Data.Id,
                            OptionId = addedOption.Data.Id,
                            ImageUrl = uploadedImage.Message
                        };

                        var addedImage = _productSrv.AddProductImage(newImage);
                    }
                }
            });

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
