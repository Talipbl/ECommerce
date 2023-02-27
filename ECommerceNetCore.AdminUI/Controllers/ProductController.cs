using ECommerceNetCore.AdminUI.Helpers;
using ECommerceNetCore.AdminUI.Models;
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
        IBrandService _brnadSrv;
        IManufacturerService _manufacturerSrv;
        ISystemService _systemsrv;
        IFileHelper _fileHelper;
        public ProductController(ICategoryService categorySrv, IProductService productSrv, IFileHelper fileHelper, IBrandService brnadSrv, IManufacturerService manufacturerSrv, ISystemService systemsrv)
        {
            _categorySrv = categorySrv;
            _productSrv = productSrv;
            _fileHelper = fileHelper;
            _brnadSrv = brnadSrv;
            _manufacturerSrv = manufacturerSrv;
            _systemsrv = systemsrv;
        }

        [HttpGet]
        [Route("yeni-urun")]
        public IActionResult AddProduct()
        {
            ProductModifyModel model = new ProductModifyModel();
            model.Brands = _brnadSrv.GetBrands().Data;
            model.Manufacturers = _manufacturerSrv.GetManufacturers().Data;
            model.Categories = _categorySrv.GetCategories().Data;
            model.Status = _systemsrv.GetSystemStatus().Data;
            model.Currencies = _systemsrv.GetCurrencies().Data;
            model.VatRatios = _systemsrv.GetVatRatios().Data;
            model.UnitTypes = _systemsrv.GetUnitTypes().Data;
            return View(model);
        }

        [HttpGet]
        [Route("duzenle/{pId}")]
        public IActionResult UpdateProduct(int pId)
        {
            ProductModifyModel model = new ProductModifyModel();
            var product = _productSrv.GetProductMaster(pId);
            if (product.Data is null)
            {
                return RedirectToAction("ListProduct");
            }

            model.Product = product.Data;
            model.Brands = _brnadSrv.GetBrands().Data;
            model.Manufacturers = _manufacturerSrv.GetManufacturers().Data;
            model.Categories = _categorySrv.GetCategories().Data;
            model.Status = _systemsrv.GetSystemStatus().Data;
            model.Currencies = _systemsrv.GetCurrencies().Data;
            model.VatRatios = _systemsrv.GetVatRatios().Data;
            model.UnitTypes = _systemsrv.GetUnitTypes().Data;
            return View(model);
        }

        [HttpPost]
        [Route("add")]
        public async Task<JsonResult> AddProductAsync([FromBody] ProductMasterModelDto masterProduct)
        {
            Result jsonResult = new Result(true, EntityConsts.AddedSuccess);
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
                MinmumOrder = masterProduct.MinimumOrder,
                SellerCode = masterProduct.SellerCode,
                SellerUrl = masterProduct.SellerUrl,
                StockCode = masterProduct.StockCode,
                StatusId = masterProduct.StatusId,
                CreatedDate = DateTime.Now
            };

            var addedProduct = _productSrv.AddProduct(product);

            if (!addedProduct.Success)
            {
                return Json(new ErrorResult(EntityConsts.AddedError));
            }

            GnlProductCategory category = new GnlProductCategory()
            {
                ProductId = addedProduct.Data.Id,
                SubCategoryId = masterProduct.SubCategoryId,
            };

            var addedCategory = _productSrv.AddProductCategory(category);

            foreach (var option in masterProduct.ProductOptions)
            {
                DateTime parsedDatetime;
                DateTime.TryParseExact(option.AvailableDate, "dd/MM/yyyy HH:mm", null, DateTimeStyles.None, out parsedDatetime);

                GnlProductOption productOption = new GnlProductOption()
                {
                    ProductId = addedProduct.Data.Id,
                    OptionName = option.OptionName,
                    UnitTypeId = option.UnitTypeId,
                    UnitOfStock = option.UnitOfStock,
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

                if (!addedOption.Success)
                {
                    jsonResult = new ErrorResult("", $"/urunler/duzenle/{addedProduct.Data.Id}");
                    break;
                }

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
                    if (!uploadedImage.Success)
                    {
                        jsonResult = new SuccessResult(EntityConsts.AddedSuccess, $"/urunler/duzenle/{addedProduct.Data.Id}");
                        break;
                    }

                    GnlProductImage newImage = new GnlProductImage()
                    {
                        ProductId = addedProduct.Data.Id,
                        OptionId = addedOption.Data.Id,
                        ImageUrl = uploadedImage.Message
                    };

                    var addedImage = _productSrv.AddProductImage(newImage);
                }
            }

            return Json(jsonResult);
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
