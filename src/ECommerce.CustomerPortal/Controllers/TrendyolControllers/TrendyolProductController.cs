using ECommerce.CustomerPortal.Models;
using ECommerce.Trendyol;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Trendyol.Client;

namespace Ecommerce.Trendyol
{
    [Route("trendyol/product")]
    public class TrendyolProductController : Controller
    {
        private readonly ITrendyolProductService _trendyolService;
        public TrendyolProductController(ITrendyolProductService trendyolService)
        {
            _trendyolService = trendyolService;
        }

        [HttpGet]
        [Route("list")]
        public IActionResult Products()
        {
            return View();
        }

        [HttpGet]
        [Route("detail/{barcode}")]
        public async Task<IActionResult> ProductDetails(string barcode) 
        {
            var result = await _trendyolService.GetProductsAsync(new ProductQueryParametersDTO() { Barcode = barcode });
            return View(result.Data.Content.FirstOrDefault());
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateProduct([FromBody] ModifyProductRequestVM product)
        {
            var result = await _trendyolService.CreateProductAsync(new TrendyolProductDTO()
            {
                Barcode = product.Barcode,
                StockCode = product.StockCode,
                CategoryId = product.CategoryId,
                BrandId = product.BrandId,
                Title = product.Title,
                Description = product.Description,
                Images = product.Images,
                Attributes = product.Attributes,
                VatRate = product.VatRate,
                SalePrice = product.SalePrice,
                ListPrice = product.ListPrice
            });
            return Json(result);
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateProduct([FromBody] ModifyProductRequestVM product)
        {
            var result = await _trendyolService.UpdateProductAsync(new TrendyolProductDTO()
            {
                Barcode = product.Barcode,
                StockCode = product.StockCode,
                CategoryId = product.CategoryId,
                BrandId = product.BrandId,
                Title = product.Title,
                Description = product.Description,
                Images = product.Images,
                Attributes = product.Attributes,
                VatRate = product.VatRate,
                SalePrice = product.SalePrice,
                ListPrice = product.ListPrice
            });
            return Json(result);
        }

        [HttpPost]
        [Route("getProducts")]
        public async Task<IActionResult> GetProducts([FromBody] DataTableRequestVM request)
        {
            DataTableVM<ProductVM> tableVM = new();

            int draw = request.Draw;
            int startRec = request.GetStartPage();
            int pageSize = request.Length;

            var products = await _trendyolService.GetProductsAsync(new()
            {
                Page = startRec,
                Size = pageSize,
                Barcode = request.Barcode,
                StockCode = request.StockCode,
                OnSale = request.Status == 1 ? QueryOption.True : QueryOption.All,
                Archived = request.Status == 2 ? QueryOption.True: QueryOption.All,
                Rejected = request.Status == 2 ? QueryOption.True: QueryOption.All,
            });

            List<ProductVM> productVMs = products.Data.Content.Select(ProductVM.GetProductVM).ToList();

            tableVM.data = productVMs;
            tableVM.recordsTotal = products.Data.TotalElements;
            tableVM.recordsFiltered = products.Data.TotalElements;
            tableVM.draw = request.Draw;

            return Json(tableVM);
        }

        [HttpPost]
        [Route("updatePriceInventory")]
        public async Task<IActionResult> UpdatePriceInventory([FromBody] List<TrendyolPriceAndInventoryDTO> request)
        {
            var result = await _trendyolService.UpdatePriceAndInventoryAsync(request);
            return Json(result);
        }

        [HttpGet]
        [Route("getBrands/{search}")]
        public async Task<IActionResult> GetBrands(string search)
        {
            var result = await _trendyolService.GetBrandsAsync(search, 50);
            return Json(result);
        }

        [HttpGet("getCategories/{search}")]
        public async Task<IActionResult> GetCategories(string search)
        {
            var result = await _trendyolService.GetCategoriesAsync(search, 50);
            return Json(result);
        }
    }
}
