using ECommerce.Core.Persistence;
using ECommerce.Persistence;

namespace ECommerce.Carrier;

public class EfCarrierRepository : EfBaseEntityRepository<DefCarrier, ECommerceContext>, ICarrierRepository
{

}
