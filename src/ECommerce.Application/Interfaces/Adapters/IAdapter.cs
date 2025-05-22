namespace ECommerce.Application.Interfaces.Adapters
{
    public interface IAdapter
    {
        TDestination Adapt<TDestination>(object source);
    }
}
