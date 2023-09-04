using ECommerce.Core.Persistance;
using ECommerce.Application.Interfaces.Repositories;
using ECommerce.Domain.Entities;
using ECommerce.Persistance.Context;

namespace ECommerce.Carrier
{
    public class EfCarrierRepository : EfBaseEntityRepository<DefCarrier, ECommerceContext>, ICarrierRepository
    {

    }
}
