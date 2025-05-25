using Ecommerce.Shared.Utilities.Results;
using ECommerce.Systems;

namespace ECommerce.Admin
{
    public interface IAdminService
    {
        IDataResult<DefAdmin> AddAdmin(DefAdmin admin);
        IResult UpdateAdmin(DefAdmin admin);
        IResult DeleteAdmin(int adminId);
        IListResult<DefAdmin> GetAdmins(int statusId = (int)StatusTypes.Active);
        IDataResult<DefAdmin> GetAdmin(int adminId);
        IDataResult<DefAdmin> GetAdmin(string nameOrMail);
    }
}
