using AutoMapper;
using Marketplace.Trendyol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Trendyol
{
    public class TrendyolWebSearchResultMapping : Profile
    {
        public TrendyolWebSearchResultMapping()
        {
            CreateMap<WebSearchResultModel.ResultModel, TrendyolWebSearchResultDto>();

            CreateMap<WebSearchResultModel.Widget, TrendyolWebSearchResultDto.Widget>();
            CreateMap<WebSearchResultModel.Widget.ConfigurationModel, TrendyolWebSearchResultDto.Widget.ConfigurationModel>();
            CreateMap<WebSearchResultModel.Product.BrandModel, TrendyolWebSearchResultDto.Product.BrandModel>();
            CreateMap<WebSearchResultModel.Product.RatingScoreModel, TrendyolWebSearchResultDto.Product.RatingScoreModel>();
            CreateMap<WebSearchResultModel.Product.Section, TrendyolWebSearchResultDto.Product.Section>();
            CreateMap<WebSearchResultModel.Product.Variant, TrendyolWebSearchResultDto.Product.Variant>();
            CreateMap<WebSearchResultModel.Product.PriceModel, TrendyolWebSearchResultDto.Product.PriceModel>();
            CreateMap<WebSearchResultModel.Product.PriceLabelModel, TrendyolWebSearchResultDto.Product.PriceLabelModel>();
            CreateMap<WebSearchResultModel.Product.Badge, TrendyolWebSearchResultDto.Product.Badge>();
            CreateMap<WebSearchResultModel.Product.Stamp, TrendyolWebSearchResultDto.Product.Stamp>();
            CreateMap<WebSearchResultModel.Product.Promotion, TrendyolWebSearchResultDto.Product.Promotion>();
            CreateMap<WebSearchResultModel.Product, TrendyolWebSearchResultDto.Product>();
        }
    }
}
