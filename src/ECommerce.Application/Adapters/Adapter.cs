using AutoMapper;
using ECommerce.Application.Adapters;
using ECommerce.Trendyol;
using Trendyol.Client;

namespace ECommerce.Application
{
    public class Adapter(IMapper mapper) : IAdapter
    {
        protected readonly IMapper _mapper = mapper;
        public TDestination Adapt<TDestination>(object source)
        {
            return _mapper.Map<TDestination>(source);
        }
    }
}
