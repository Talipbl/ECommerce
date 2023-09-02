using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Application.Utilities;
using ECommerceNetCore.Domain.Entities;
using ECommerceNetCore.Persistance.Context;
using Microsoft.Data.SqlClient;

namespace ECommerceNetCore.Persistance.Repositories.EntityFrameworkCore
{
    public class EfUserRepository : EfBaseEntityRepository<GnlUser, EcommerceNetCoreContext>, IUserRepository
    {
        public IListResult<GnlUser> GetAllUsers(int statusId = 1, int start = 0, int take = 25)
        {
            var result = GetAll(x => statusId != 0 ? x.StatusId == statusId : x.StatusId != statusId, x => x.Id, (int)SortOrder.Ascending, start, take).ToList();
            var count = GetCount();

            return new ListResult<GnlUser>(result, count);
        }
    }
}
