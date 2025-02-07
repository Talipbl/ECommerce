using ECommerce.CustomerPortal.Models;
using ECommerce.Order;
using ECommerce.Trendyol;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Trendyol
{
    [Route("trendyol/order")]
    public class TrendyolOrderController : Controller
    {
        private readonly ITrendyolOrderService _orderService;
        public TrendyolOrderController(ITrendyolOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Route("list")]
        public IActionResult Orders()
        {
            return View();
        }

        [HttpPost]
        [Route("getOrders")]
        public async Task<IActionResult> GetOrders([FromBody] DataTableRequestVM request)
        {
            DataTableVM<OrderVM> tableVM = new();

            int draw = request.Draw;
            int startRec = request.GetStartPage();
            int pageSize = request.Length;

            var orders = await _orderService.GetOrdersAsync(new()
            {
                Page = startRec,
                Size = pageSize,
            });

            List<OrderVM> ordersVMs = orders.Data.Content.Select(OrderVM.GetOrderVM).ToList();

            tableVM.data = ordersVMs;
            tableVM.recordsTotal = orders.Data.TotalElements;
            tableVM.recordsFiltered = orders.Data.TotalElements;
            tableVM.draw = request.Draw;

            return Json(tableVM);
        }
    }
}
