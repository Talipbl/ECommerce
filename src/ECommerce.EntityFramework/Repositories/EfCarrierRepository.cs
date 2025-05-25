using ECommerce.EntityFramework;


namespace ECommerce.Carrier;

public class EfCarrierRepository : EfBaseEntityRepository<DefCarrier, ECommerceContext>, ICarrierRepository
{

}
