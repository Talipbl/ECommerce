using ECommerce.Application.Interfaces.Repositories;
using ECommerce.Application.Utilities;
using ECommerce.Application.Utilities.Results.Abstracts;
using ECommerce.Domain.Entities;
using ECommerce.Persistance.Context;
using Microsoft.Data.SqlClient;

namespace ECommerce.Persistance.Repositories.EFCore
{
    public class EfUserRepository : EfBaseEntityRepository<GnlUser, ECommerceContext>, IUserRepository
    {
        public IListResult<GnlUser> GetAllUsers(int statusId = 1, int start = 0, int take = 25)
        {
            var result = GetAll(x => statusId != 0 ? x.StatusId == statusId : x.StatusId != statusId, x => x.Id, (int)SortOrder.Ascending, start, take).ToList();
            var count = GetCount();

            return new ListResult<GnlUser>(result, count);
        }
    }
}
