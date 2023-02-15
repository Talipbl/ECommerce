using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Domain.Entities;
using ECommerceNetCore.Persistance.Context;

namespace ECommerceNetCore.Persistance.Repositories
{
    public class EfUserRepository : EfBaseEntityRepository<GnlUser, EcommerceNetCoreContext>, IUserRepository
    {

    }
}
