using Microsoft.AspNetCore.Mvc;

namespace ECommerceNetCore.AdminUI.Controllers
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
