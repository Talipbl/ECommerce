using ECommerce.Core.Persistance;
using ECommerce.Persistance.Context;

namespace ECommerce.User
{
    public class EfUserMailQueueRepository : EfBaseEntityRepository<GnlUserMailQueue, ECommerceContext>, IUserMailQueueRepository
    {

    }
}
