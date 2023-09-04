using ECommerce.Application.Utilities.Results.Abstracts;
using ECommerce.Domain.Common.Enumarations;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Interfaces.Services.Order
{
    public interface IOrderService
    {
        #region Order
        IDataResult<GnlOrder> AddOrder(GnlOrder order);
        IResult UpdateOrder(GnlOrder order);
        IResult DeleteOrder(int orderId);
        IListResult<GnlOrder> GetOrders(int userId = 0, string orderCode = "", int carrierId = 0, int couponId = 0, int statusTypeId = (int)StatusTypes.Active);
        IDataResult<GnlOrder> GetOrder(int orderId);
        #endregion

        #region Order Payment
        IDataResult<GnlOrderPayment> AddOrderPayment(GnlOrderPayment orderPayment);
        IResult UpdateOrderPayment(GnlOrderPayment orderPayment);
        IResult DeleteOrderPayment(int orderPaymentId);
        IListResult<GnlOrderPayment> GetOrderPayments(int orderId = 0, int statusTypeId = (int)StatusTypes.PaymentConfirmed);
        IDataResult<GnlOrderPayment> GetOrderPayment(int orderPaymentId, int statusTypeId = (int)StatusTypes.All);
        #endregion

        #region Order Product
        IDataResult<GnlOrderProduct> AddOrderProduct(GnlOrderProduct orderProduct);
        IResult UpdateOrderProduct(GnlOrderProduct orderProduct);
        IResult DeleteOrderProduct(int orderProductId);
        IListResult<GnlOrderProduct> GetOrderProducts(int orderId = 0, int productId = 0);
        IDataResult<GnlOrderProduct> GetOrderProduct(int orderProductId);
        #endregion
    }
}
