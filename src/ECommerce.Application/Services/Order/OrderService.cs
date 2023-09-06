using ECommerce.Core.Application;

namespace ECommerce.Order;

public class OrderService : IOrderService
{
    public IDataResult<GnlOrder> AddOrder(GnlOrder order)
    {
        throw new NotImplementedException();
    }

    public IResult DeleteOrder(int orderId)
    {
        throw new NotImplementedException();
    }

    public IDataResult<GnlOrder> GetOrder(int orderId)
    {
        throw new NotImplementedException();
    }

    public IListResult<GnlOrder> GetOrders(int userId = 0, string orderCode = "", int carrierId = 0, int couponId = 0, int statusTypeId = 1)
    {
        throw new NotImplementedException();
    }

    public IResult UpdateOrder(GnlOrder order)
    {
        throw new NotImplementedException();
    }
}
