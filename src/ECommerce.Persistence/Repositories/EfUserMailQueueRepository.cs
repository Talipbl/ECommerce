using ECommerce.Core.Persistence;
using ECommerce.Persistence;

namespace ECommerce.User;

public class EfUserMailQueueRepository : EfBaseEntityRepository<GnlUserMailQueue, ECommerceContext>, IUserMailQueueRepository
{

}
