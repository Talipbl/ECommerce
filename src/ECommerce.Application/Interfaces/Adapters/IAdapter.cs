using ECommerce.Trendyol;
using Trendyol.Client;

namespace ECommerce.Application.Interfaces.Adapters
{
    public interface IAdapter
    {
        TDestination Adapt<TDestination>(object source);
        TrendyolErrorResultDTO AdaptErrorResult(object model);
    }
}
