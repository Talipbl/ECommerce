using AutoMapper;
using Trendyol.Client;

namespace ECommerce.Trendyol
{
    public class TrendyolTypeConvertProfile : Profile
    {
        public TrendyolTypeConvertProfile()
        {
            CreateMap<DateTime, long>().ConvertUsing(new DateTimeConverter());
            CreateMap<long, DateTime>().ConvertUsing(new UnixMillisecondsToDateTimeConverter());
            CreateMap<QueryOption, QueryBooleanOption>().ConvertUsing<QueryOptionConverter>();
        }
    }
}
