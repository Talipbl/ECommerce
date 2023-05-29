using ECommerceNetCore.AdminUI.Helpers;
using ECommerceNetCore.AdminUI.Models;
using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Application.Results;
using ECommerceNetCore.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace ECommerceNetCore.AdminUI.Controllers
{
    [Route("category")]
    [Route("kategori")]
    public class CategoryController : Controller
    {
        ICategoryService _categorySrv;
        public CategoryController(ICategoryService categorySrv)
        {
            _categorySrv = categorySrv;
        }

        [HttpGet]
        [Route("subcategories")]
        public JsonResult GetSubCategories(int parentId, bool isParent = false)
        {
            var result = _categorySrv.GetSubCategories(parentId, isParent).Data;
            return Json(result);
        }

        [HttpGet]
        [Route("yeni")]
        public IActionResult AddCategory()
        {
            var categories = _categorySrv.GetCategories().Data;
            return View(categories);
        }


        [HttpPost]
        [Route("subcategory/add")]
        public JsonResult AddSubCategory([FromBody] CategoryModifyModel model) //Model gelmiyor.
        {
            DefSubCategory category = new DefSubCategory()
            {
                CategoryName = model.CategoryName,
                Description = model.Description,
                ParentId = model.ParentId,
                IsParent = model.IsParent
            };

            var result = _categorySrv.AddSubCategory(category);
            return Json(result);
        }
    }
}
