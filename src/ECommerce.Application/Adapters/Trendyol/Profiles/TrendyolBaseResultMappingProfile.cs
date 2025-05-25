using AutoMapper;
using Trendyol.Client;

namespace ECommerce.Trendyol
{
    public class TrendyolBaseResultMappingProfile : Profile
    {
        public TrendyolBaseResultMappingProfile()
        {
            CreateMap<ErrorResultModel, TrendyolErrorResultDTO>();
            CreateMap<ErrorResultModel.ErrorModel, TrendyolErrorResultDTO.ErrorModelDTO>();
        }
    }
}
