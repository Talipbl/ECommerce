using ECommerceNetCore.AdminUI.Helpers;
using ECommerceNetCore.Application.Aspects;
using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Domain.Common;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace ECommerceNetCore.AdminUI.Controllers
{
    [Route("products")]
    [Route("urunler")]
    public class ProductController : Controller
    {
        ICategoryService _categorySrv;
        public ProductController(ICategoryService categorySrv)
        {
            _categorySrv = categorySrv;
        }

        [HttpGet]
        [Route("yeni-urun")]
        public IActionResult AddProduct()
        {
            var categories = _categorySrv.GetCategories().Data;
            return View(categories);
        }

        [HttpGet]
        [Route("option/partial")]
        //[SecurityOperationAspect(Level:(int)UserLevels.High)]
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
