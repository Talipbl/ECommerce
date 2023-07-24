using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Application.Results;
using ECommerceNetCore.Domain.Entities;
using ECommerceNetCore.Persistance.Context;

namespace ECommerceNetCore.Persistance.Repositories
{
    public class EfUserRepository : EfBaseEntityRepository<GnlUser, EcommerceNetCoreContext>, IUserRepository
    {
        public IListResult<GnlUser> GetAllUsers(int statusId = 1)
        {
            var result = this.GetAll(x=> statusId != 0 ? x.StatusId == statusId : x.StatusId != statusId).ToList();
            var count = this.GetCount();

            return new ListResult<GnlUser>(result, count);
        }
    }
}
