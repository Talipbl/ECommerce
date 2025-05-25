using ECommerce.Trendyol;
using Trendyol.Client;

namespace ECommerce.Application.Adapters
{
    public interface IAdapter
    {
        TDestination Adapt<TDestination>(object source);
    }
}
