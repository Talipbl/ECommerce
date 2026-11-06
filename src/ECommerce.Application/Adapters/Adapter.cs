using ECommerce.Application.Interfaces.Adapters;
using MapsterMapper;

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
