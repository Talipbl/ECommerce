using ECommerce.Application.Interfaces.Repositories;
using ECommerce.Domain.Entities;
using ECommerce.Persistance.Context;

namespace ECommerce.Persistance.Repositories.EFCore
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
