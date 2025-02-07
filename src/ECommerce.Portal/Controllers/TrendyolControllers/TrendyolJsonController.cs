using AutoMapper;
using ECommerce.AdminUI.Helpers;
using ECommerce.AdminUI.Models.Trendyol;
using ECommerce.Core.Application;
using ECommerce.Trendyol;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;

namespace ECommerce.AdminUI.Controllers.TrendyolControllers
{
    [Route("trendyol/crawler")]
    public class TrendyolJsonController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly TrendyolConfigurationModel _marketplaceModel;

        ITrendyolProductService _trendyolService;
        IMapper _mapper;

        public TrendyolJsonController(ITrendyolProductService trendyolService, IMapper mapper, IConfiguration configuration)
        {
            _trendyolService = trendyolService;
            _configuration = configuration;
            _mapper = mapper;

            _marketplaceModel = _configuration.GetSection("TrendyolConfiguration").Get<TrendyolConfigurationModel>();
        }

        [Route("search")]
        [HttpPost]
        public async Task<JsonResult> FindProducts([FromBody] CrawlerSearchModel model)
        {
            if (string.IsNullOrEmpty(model.Url))
                return Json(null);

            var result = await _trendyolService.SearchCrawlerProducts(model.Url, model.Page);

            var render = await this.RenderViewPathAsync("~/Views/Trendyol/Partials/CrawlerProductsPartial.cshtml", result.Data);
            return Json(render);
        }

        [Route("add/trendyol")]
        [HttpPost]
        public async Task<JsonResult> AddToTrendyol([FromBody] int[] ids)
        {
            var createResult = await _trendyolService.CreateCopyProduct(ids);
            if (createResult.Success)
                return Json(new SuccessResult("Ürünler başarıyla gönderildi."));
            
            return Json(new ErrorDataResult<List<ErrorModelDto>>(createResult.Additional.Errors));
        }
    }
}
