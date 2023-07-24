using ECommerceNetCore.Application.Results;
using ECommerceNetCore.Domain.Common;
using ECommerceNetCore.Domain.Entities;
using Microsoft.Data.SqlClient.DataClassification;

namespace ECommerceNetCore.Application.Interfaces
{
    public interface IUserRepository : IBaseEntityRepository<GnlUser>
    {
        IListResult<GnlUser> GetAllUsers(int statusId = (int)StatusTypes.Active);
    }
}
