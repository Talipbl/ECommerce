using ECommerce.Trendyol;
using ECommerce.Trendyol.Order;
using Trendyol.Client;
using FailureToSupplyReason = ECommerce.Trendyol.FailureToSupplyReason;

namespace ECommerce.UnitTests.Trendyol;

public class TrendyolOrderAdapterTests
{
    private readonly ITrendyolOrderAdapter _adapter = TrendyolMappingFixture.CreateOrderAdapter();

    [Fact]
    public void AdaptFailureRequest_sets_reason_id_and_lines()
    {
        var dto = new FailureToSupplyReuqestDTO
        {
            PackageId = "p-1",
            Reason = FailureToSupplyReason.StockDepleted,
            Lines = [new FailureToSupplyReuqestDTO.Line { LineId = 10, Quantity = 2 }]
        };

        var request = _adapter.AdaptFailureRequest(dto);

        request.ReasonId.ShouldBe(500);
        var line = request.Lines.ShouldHaveSingleItem();
        line.LineId.ShouldBe(10);
        line.Quantity.ShouldBe(2);
    }

    [Fact]
    public void AdaptUpdateRequest_sets_status_and_invoice_number()
    {
        var dto = new UpdatePackageRequestDTO
        {
            PackageId = "p-1",
            Status = PackageStatus.Invoiced,
            InvoiceNumber = "INV-1",
            Lines = [new UpdatePackageRequestDTO.Line { LineId = "10", Quantity = 1 }]
        };

        var request = _adapter.AdaptUpdateRequest(dto);

        request.Status.ShouldBe("Invoiced");
        request.Params.InvoiceNumber.ShouldBe("INV-1");
        request.Lines.ShouldHaveSingleItem().LineId.ShouldBe("10");
    }

    [Fact]
    public void Adapt_order_query_converts_dates_to_milliseconds()
    {
        var start = new DateTimeOffset(2026, 11, 1, 0, 0, 0, TimeSpan.Zero);
        var parameters = new OrderQueryParametersModelDTO
        {
            StartDate = start.UtcDateTime,
            Page = 2,
            Size = 200,
            Status = "Created"
        };

        var model = _adapter.Adapt<OrderQueryParametersModel>(parameters);

        model.StartDate.ShouldBe(start.ToUnixTimeMilliseconds());
        model.EndDate.ShouldBeNull();
        model.Page.ShouldBe(2);
        model.Size.ShouldBe(200);
        model.Status.ShouldBe("Created");
    }

    [Fact]
    public void Adapt_orders_response_maps_dates_addresses_and_lines()
    {
        var orderDate = new DateTimeOffset(2026, 11, 5, 9, 30, 0, TimeSpan.Zero);
        var response = new GetOrdersResponseModel
        {
            TotalElements = 1,
            Content =
            [
                new GetOrdersResponseModel.ContentModel
                {
                    OrderNumber = "TY-1",
                    OrderDate = orderDate.ToUnixTimeMilliseconds(),
                    ShipmentAddress = new GetOrdersResponseModel.ShipmentAddress { FirstName = "Ali", City = "İstanbul" },
                    InvoiceAddress = new GetOrdersResponseModel.InvoiceAddress { FirstName = "Ayşe", City = "Ankara" },
                    Lines = [new GetOrdersResponseModel.Line { Barcode = "A", Quantity = 2 }]
                }
            ]
        };

        var dto = _adapter.Adapt<GetOrdersResponseDTO>(response);

        var content = dto.Content.ShouldHaveSingleItem();
        content.OrderNumber.ShouldBe("TY-1");
        content.OrderDate.ShouldBe(orderDate.UtcDateTime);
        content.ShipmentAddress.City.ShouldBe("İstanbul");
        content.InvoiceAddress.FirstName.ShouldBe("Ayşe");
        content.Lines.ShouldHaveSingleItem().Quantity.ShouldBe(2);
    }
}
