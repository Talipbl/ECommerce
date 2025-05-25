using ECommerce.EntityFramework;


namespace ECommerce.User;

public class EfUserMailQueueRepository : EfBaseEntityRepository<GnlUserMailQueue, ECommerceContext>, IUserMailQueueRepository
{

}
