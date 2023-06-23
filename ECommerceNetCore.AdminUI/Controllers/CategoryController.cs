using ECommerceNetCore.AdminUI.Helpers;
using ECommerceNetCore.AdminUI.Models;
using ECommerceNetCore.Application.DataTransferObjects;
using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Application.Results;
using ECommerceNetCore.Domain;
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

        [Route("ana-kategoriler")]
        public IActionResult MainCategories()
        {
            return View();
        }

        [Route("alt-kategoriler")]
        public IActionResult SubCategories()
        {
            return View();
        }

        [HttpGet]
        [Route("list")]
        public JsonResult GetCategories()
        {
            DataTableModel<DefCategory> model = new DataTableModel<DefCategory>();

            int draw = Convert.ToInt32(HttpContext.Request.Query["draw"]);
            int startRec = Convert.ToInt32(HttpContext.Request.Query["start"]);
            int pageSize = Convert.ToInt32(HttpContext.Request.Query["length"]);

            var result = _categorySrv.GetCategories(startRec, pageSize);

            model.data = result.Data;
            model.recordsTotal = result.Count;
            model.recordsFiltered = result.Count;
            model.draw = draw;

            return Json(model);
        }

        [HttpGet]
        [Route("subcategory/list")]
        public JsonResult GetSubCategories()
        {
            DataTableModel<CategoryListModel> model = new DataTableModel<CategoryListModel>();

            int draw = Convert.ToInt32(HttpContext.Request.Query["draw"]);
            int startRec = Convert.ToInt32(HttpContext.Request.Query["start"]);
            int pageSize = Convert.ToInt32(HttpContext.Request.Query["length"]);

            var result = _categorySrv.GetSubCategories(startRec, pageSize);

            model.data = result.Data;
            model.recordsTotal = result.Count;
            model.recordsFiltered = result.Count;
            model.draw = draw;

            return Json(model);
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
        public JsonResult AddSubCategory([FromBody] CategoryModifyModel model)
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

        [HttpPost]
        [Route("maincategory/add")]
        public JsonResult AddCategory([FromBody] CategoryModifyModel model)
        {
            DefCategory category = new DefCategory()
            {
                CategoryName = model.CategoryName,
                Descriptipn = model.Description,
            };

            var result = _categorySrv.AddCategory(category);
            return Json(result);
        }

        [HttpPost]
        [Route("subcategory/update")]
        public JsonResult UpdateSubCategory([FromBody] CategoryModifyModel model)
        {
            var category = _categorySrv.GetSubCategory(model.Id);

            category.Data.CategoryName = model.CategoryName;
            category.Data.Description = model.Description;

            var result = _categorySrv.UpdateSubCategory(category.Data);
            return Json(result);
        }

        [HttpPost]
        [Route("maincategory/update")]
        public JsonResult UpdateCategory([FromBody] CategoryModifyModel model)
        {
            var category = _categorySrv.GetCategory(model.Id);

            category.Data.CategoryName = model.CategoryName;
            category.Data.Descriptipn = model.Description;

            var result = _categorySrv.UpdateCategory(category.Data);
            return Json(result);
        }
    }
}
