using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Domain.Entities;
using ECommerceNetCore.Persistance.Context;

namespace ECommerceNetCore.Persistance.Repositories.EntityFrameworkCore
{
    public class EfAdminRepository : EfBaseEntityRepository<DefAdmin, EcommerceNetCoreContext>, IAdminRepository
    {
        public DefAdmin GetAdmin(string nameOrMail)
        {
            var result = Get(x => x.MailAdress == nameOrMail || x.UserName == nameOrMail);
            return result;
        }
    }
}
