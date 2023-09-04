using ECommerce.Core.Application;

namespace ECommerce.Order
{
    public interface IOrderPaymentService
    {
        IDataResult<GnlOrderPayment> AddOrderPayment(GnlOrderPayment orderPayment);
        IResult UpdateOrderPayment(GnlOrderPayment orderPayment);
        IResult DeleteOrderPayment(int orderPaymentId);
        IListResult<GnlOrderPayment> GetOrderPayments(int orderId = 0, int statusTypeId = (int)StatusTypes.PaymentConfirmed);
        IDataResult<GnlOrderPayment> GetOrderPayment(int orderPaymentId, int statusTypeId = (int)StatusTypes.All);
    }
}
