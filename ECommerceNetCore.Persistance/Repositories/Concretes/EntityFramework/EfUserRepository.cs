using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Application.Results;
using ECommerceNetCore.Domain.Entities;
using ECommerceNetCore.Persistance.Context;
using Microsoft.Data.SqlClient;

namespace ECommerceNetCore.Persistance.Repositories
{
    public class EfUserRepository : EfBaseEntityRepository<GnlUser, EcommerceNetCoreContext>, IUserRepository
    {
        public IListResult<GnlUser> GetAllUsers(int statusId = 1, int start = 0, int take = 25)
        {
            var result = this.GetAll<int>(x=> statusId != 0 ? x.StatusId == statusId : x.StatusId != statusId, x=>x.Id, (int)SortOrder.Ascending, start, take).ToList();
            var count = this.GetCount();

            return new ListResult<GnlUser>(result, count);
        }
    }
}
