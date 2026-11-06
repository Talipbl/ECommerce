using Mapster;
using Trendyol.Client;

namespace ECommerce.Trendyol;

public class TrendyolCommonMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // Trendyol sorgu ve cevaplarındaki tarihler Unix milisaniye cinsindendir.
        config.NewConfig<DateTime, long?>().MapWith(src => ToUnixMilliseconds(src));
        config.NewConfig<DateTime?, long?>().MapWith(src => src.HasValue ? ToUnixMilliseconds(src.Value) : null);
        config.NewConfig<long, DateTime>().MapWith(src => DateTimeOffset.FromUnixTimeMilliseconds(src).LocalDateTime);
        config.NewConfig<QueryOption, QueryBooleanOption>().MapWith(src => (QueryBooleanOption)(int)src);

        config.NewConfig<ErrorResultModel, TrendyolErrorResultDTO>();
        config.NewConfig<ErrorResultModel.ErrorModel, TrendyolErrorResultDTO.ErrorModelDTO>();
    }

    private static long? ToUnixMilliseconds(DateTime value) =>
        value == default ? null : new DateTimeOffset(value.ToUniversalTime()).ToUnixTimeMilliseconds();
}
