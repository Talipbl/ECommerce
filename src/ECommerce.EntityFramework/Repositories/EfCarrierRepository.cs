using ECommerce.Core.Persistance;
using ECommerce.Persistance;

namespace ECommerce.Carrier;

public class EfCarrierRepository : EfBaseEntityRepository<DefCarrier, ECommerceContext>, ICarrierRepository
{

}
