using ECommerce.Core.Application;

namespace ECommerce.User;

public interface IUserAddressService
{
    IDataResult<GnlUserAddress> AddUserAddress(GnlUserAddress address);
    IResult UpdateUserAddress(GnlUserAddress address);
    IResult DeleteUserAddress(int id);
    IListResult<GnlUserAddress> GetUserAddresses(int userId);
    IDataResult<GnlUserAddress> GetUserAddress(int userId, int addressId = 0, bool isDefault = true);
}
