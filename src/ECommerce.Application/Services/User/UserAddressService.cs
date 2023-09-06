using ECommerce.Core.Application;

namespace ECommerce.User;

public class UserAddressService : IUserAddressService
{
    public IDataResult<GnlUserAddress> AddUserAddress(GnlUserAddress address)
    {
        throw new NotImplementedException();
    }

    public IResult DeleteUserAddress(int id)
    {
        throw new NotImplementedException();
    }

    public IDataResult<GnlUserAddress> GetUserAddress(int userId, int addressId = 0, bool isDefault = true)
    {
        throw new NotImplementedException();
    }

    public IListResult<GnlUserAddress> GetUserAddresses(int userId)
    {
        throw new NotImplementedException();
    }

    public IResult UpdateUserAddress(GnlUserAddress address)
    {
        throw new NotImplementedException();
    }
}
