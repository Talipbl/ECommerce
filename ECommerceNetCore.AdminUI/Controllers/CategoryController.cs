using ECommerceNetCore.AdminUI.Helpers;
using ECommerceNetCore.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        public JsonResult GetSubCategories(int parentId, bool isParent)
        {
            var result = _categorySrv.GetSubCategories(parentId, isParent).Data;
            return Json(result);
        }
    }
}
