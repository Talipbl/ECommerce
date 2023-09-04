using ECommerce.Application.Utilities.Results.Abstracts;
using ECommerce.Domain.Common.Enumarations;
using ECommerce.Domain.Entities;
using Microsoft.Data.SqlClient.DataClassification;

namespace ECommerce.Application.Interfaces.Repositories.User
{
    public interface IUserRepository : IBaseEntityRepository<GnlUser>
    {
        IListResult<GnlUser> GetAllUsers(int statusId = (int)StatusTypes.Active, int start = 0, int take = 25);
    }
}
