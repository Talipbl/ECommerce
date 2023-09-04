using ECommerce.Core.Persistance;
using ECommerce.Persistance.Context;

namespace ECommerce.Admin
{
    public class EfAdminRepository : EfBaseEntityRepository<DefAdmin, ECommerceContext>, IAdminRepository
    {
        public DefAdmin GetAdmin(string nameOrMail)
        {
            var result = Get(x => x.MailAdress == nameOrMail || x.UserName == nameOrMail);
            return result;
        }
    }
}
