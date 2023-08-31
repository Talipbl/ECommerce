using Microsoft.AspNetCore.Mvc;

namespace ECommerceNetCore.AdminUI.Controllers.TrendyolControllers
{
    [Route("trendyol")]
    public class TrendyolController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("urun-bulucu")]
        public IActionResult ProductFinder()
        {
            return View();
        }
    }
}
