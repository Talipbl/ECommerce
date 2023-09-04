using ECommerce.Core.Persistance;
using ECommerce.Persistance;

namespace ECommerce.User;

public class EfUserMailQueueRepository : EfBaseEntityRepository<GnlUserMailQueue, ECommerceContext>, IUserMailQueueRepository
{

}
