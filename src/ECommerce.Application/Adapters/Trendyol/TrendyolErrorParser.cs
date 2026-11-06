using Newtonsoft.Json;
using Trendyol.Client;

namespace ECommerce.Trendyol;

public static class TrendyolErrorParser
{
    public static ErrorResultModel Parse(object? body)
    {
        var text = body?.ToString() ?? string.Empty;

        try
        {
            var parsed = JsonConvert.DeserializeObject<ErrorResultModel>(text);
            if (parsed?.Errors is { Count: > 0 })
                return parsed;
        }
        catch (JsonException)
        {
        }

        return new ErrorResultModel { Errors = [new ErrorResultModel.ErrorModel { Message = text }] };
    }
}
