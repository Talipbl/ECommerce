using AutoMapper;
using Trendyol.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Trendyol
{
    public class TrendyolWebSearchMappingProfile : Profile
    {
        public TrendyolWebSearchMappingProfile()
        {
            CreateMap<WebSearchResultModel.ResultModel, TrendyolWebSearchResultDTO>();

            CreateMap<WebSearchResultModel.Widget, TrendyolWebSearchResultDTO.Widget>();
            CreateMap<WebSearchResultModel.Widget.ConfigurationModel, TrendyolWebSearchResultDTO.Widget.ConfigurationModel>();
            CreateMap<WebSearchResultModel.Product.BrandModel, TrendyolWebSearchResultDTO.Product.BrandModel>();
            CreateMap<WebSearchResultModel.Product.RatingScoreModel, TrendyolWebSearchResultDTO.Product.RatingScoreModel>();
            CreateMap<WebSearchResultModel.Product.Section, TrendyolWebSearchResultDTO.Product.Section>();
            CreateMap<WebSearchResultModel.Product.Variant, TrendyolWebSearchResultDTO.Product.Variant>();
            CreateMap<WebSearchResultModel.Product.PriceModel, TrendyolWebSearchResultDTO.Product.PriceModel>();
            CreateMap<WebSearchResultModel.Product.PriceLabelModel, TrendyolWebSearchResultDTO.Product.PriceLabelModel>();
            CreateMap<WebSearchResultModel.Product.Badge, TrendyolWebSearchResultDTO.Product.Badge>();
            CreateMap<WebSearchResultModel.Product.Stamp, TrendyolWebSearchResultDTO.Product.Stamp>();
            CreateMap<WebSearchResultModel.Product.Promotion, TrendyolWebSearchResultDTO.Product.Promotion>();
            CreateMap<WebSearchResultModel.Product, TrendyolWebSearchResultDTO.Product>();
        }
    }
}
