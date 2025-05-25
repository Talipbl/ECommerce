
using Ecommerce.Shared.Utilities.Results;
using ECommerce.Systems;

namespace ECommerce.Order;

public interface IOrderService
{
    IDataResult<GnlOrder> AddOrder(GnlOrder order);
    IResult UpdateOrder(GnlOrder order);
    IResult DeleteOrder(int orderId);
    IListResult<GnlOrder> GetOrders(int userId = 0, string orderCode = "", int carrierId = 0, int couponId = 0, int statusTypeId = (int)StatusTypes.Active);
    IDataResult<GnlOrder> GetOrder(int orderId);
}
