using ECommerceNetCore.Application.DataTransferObjects;
using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Domain.Common;
using ECommerceNetCore.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceNetCore.AdminUI.Controllers
{
    [Route("uyeler")]
    [Route("users")]
    public class UserController : Controller
    {
        IUserService _userSrv;

        public UserController(IUserService userSrc)
        {
            _userSrv = userSrc;
        }

        [Route("")]
        public IActionResult Users()
        {
            return View();
        }

        [HttpGet]
        [Route("list")]
        public JsonResult GetList()
        {
            DataTableModel<GnlUser> model = new DataTableModel<GnlUser>();

            //TODO: Filtreleme işlemi yapılacak.
            //int statusId = Convert.ToInt32(HttpContext.Request.Query["status"]);

            int draw = Convert.ToInt32(HttpContext.Request.Query["draw"]);
            int startRec = Convert.ToInt32(HttpContext.Request.Query["start"]);
            int pageSize = Convert.ToInt32(HttpContext.Request.Query["length"]);

            var result = _userSrv.GetAllUsers((int)StatusTypes.All, startRec, pageSize);

            model.data = result.Data;
            model.recordsTotal = result.Count;
            model.recordsFiltered = result.Count;
            model.draw = draw;

            return Json(model);
        }
    }
}
