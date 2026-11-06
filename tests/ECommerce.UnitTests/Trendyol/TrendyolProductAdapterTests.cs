using ECommerce.Trendyol;
using Trendyol.Client;

namespace ECommerce.UnitTests.Trendyol;

public class TrendyolProductAdapterTests
{
    private readonly ITrendyolProductAdapter _adapter = TrendyolMappingFixture.CreateProductAdapter();

    [Fact]
    public void AdaptProductsRequest_maps_items_and_skips_empty_images()
    {
        var dto = new ProductRequestDTO
        {
            Barcode = "BRK-1",
            Title = "Tişört",
            ProductMainId = 42,
            BrandId = 7,
            CategoryId = 11,
            Quantity = 5,
            DimensionalWeight = 2,
            ListPrice = 200,
            SalePrice = 150,
            VatRate = 20,
            Images = ["https://cdn/a.jpg", " ", "https://cdn/b.jpg"],
            Attributes = [new RequestAttributeDTO { AttributeId = 1, AttributeValueId = 2 }]
        };

        var request = _adapter.AdaptProductsRequest([dto]);

        var item = request.Items.ShouldHaveSingleItem();
        item.Barcode.ShouldBe("BRK-1");
        item.ProductMainId.ShouldBe("42");
        item.DimensionalWeight.ShouldBe(2);
        item.SalePrice.ShouldBe(150);
        item.Images.Select(i => i.Url).ShouldBe(["https://cdn/a.jpg", "https://cdn/b.jpg"]);
        item.Attributes.ShouldHaveSingleItem().AttributeValueId.ShouldBe(2);
    }

    [Fact]
    public void AdaptProductResponse_maps_image_urls()
    {
        var model = new ProductModel
        {
            Barcode = "BRK-1",
            ProductMainId = "42",
            Images = [new ImageModel { Url = "https://cdn/a.jpg" }, new ImageModel { Url = "" }]
        };

        var dto = _adapter.AdaptProductResponse(model);

        dto.Barcode.ShouldBe("BRK-1");
        dto.ProductMainId.ShouldBe(42);
        dto.Images.ShouldBe(["https://cdn/a.jpg"]);
    }

    [Fact]
    public void AdaptPriceAndInventoryRequest_maps_all_items()
    {
        var request = _adapter.AdaptPriceAndInventoryRequest(
        [
            new PriceAndInventoryUpdateRequestDTO { Barcode = "A", Quantity = 3, SalePrice = 10, ListPrice = 12 },
            new PriceAndInventoryUpdateRequestDTO { Barcode = "B", Quantity = 0, SalePrice = 20, ListPrice = 25 }
        ]);

        request.Items.Select(i => (i.Barcode, i.Quantity, i.SalePrice, i.ListPrice))
            .ShouldBe([("A", 3, 10d, 12d), ("B", 0, 20d, 25d)]);
    }

    [Fact]
    public void Adapt_maps_barcodes_to_delete_request()
    {
        var request = _adapter.Adapt<DeleteProductRequestModel>(new List<string> { "A", "B" });

        request.Items.Select(i => i.Barcode).ShouldBe(["A", "B"]);
    }

    [Fact]
    public void Adapt_maps_product_list_response_with_image_urls()
    {
        var response = new GetProductsResponseModel
        {
            Page = 1,
            TotalElements = 1,
            Content =
            [
                new GetProductsResponseModel.ContentModel
                {
                    Barcode = "A",
                    Images = [new ImageModel { Url = "https://cdn/a.jpg" }],
                    Attributes = [new GetProductsResponseModel.ResponseAttribute { AttributeId = 3, AttributeName = "Renk" }]
                }
            ]
        };

        var dto = _adapter.Adapt<ProductsResponseDTO>(response);

        dto.Page.ShouldBe(1);
        var content = dto.Content.ShouldHaveSingleItem();
        content.Barcode.ShouldBe("A");
        content.Images.ShouldBe(["https://cdn/a.jpg"]);
        content.Attributes.ShouldHaveSingleItem().AttributeName.ShouldBe("Renk");
    }

    [Fact]
    public void Adapt_query_parameters_converts_options_and_dates_to_milliseconds()
    {
        var start = new DateTimeOffset(2026, 11, 1, 0, 0, 0, TimeSpan.Zero);
        var parameters = new ProductQueryParametersDTO
        {
            Barcode = "A",
            Approved = QueryOption.True,
            OnSale = QueryOption.False,
            StartDate = start.UtcDateTime,
            Size = 50
        };

        var model = _adapter.Adapt<ProductQueryParametersModel>(parameters);

        model.Barcode.ShouldBe("A");
        model.Size.ShouldBe(50);
        model.Approved.ShouldBe(QueryBooleanOption.True);
        model.OnSale.ShouldBe(QueryBooleanOption.False);
        model.Archived.ShouldBe(QueryBooleanOption.All);
        model.StartDate.ShouldBe(start.ToUnixTimeMilliseconds());
        model.EndDate.ShouldBeNull();
    }

    [Fact]
    public void Adapt_maps_category_tree()
    {
        var categories = new List<CategoryModel>
        {
            new()
            {
                Id = 1,
                Name = "Giyim",
                SubCategories = [new CategoryModel { Id = 2, Name = "Tişört", ParentId = 1, SubCategories = [] }]
            }
        };

        var dto = _adapter.Adapt<List<CategoryResponseDTO>>(categories);

        var root = dto.ShouldHaveSingleItem();
        root.Name.ShouldBe("Giyim");
        var child = root.SubCategories.ShouldHaveSingleItem();
        child.ParentId.ShouldBe(1);
        child.Name.ShouldBe("Tişört");
    }

    [Fact]
    public void Adapt_maps_batch_result_with_request_items_and_dates()
    {
        var created = new DateTimeOffset(2026, 11, 6, 10, 0, 0, TimeSpan.Zero);
        var model = new BatchRequestResultModel
        {
            BatchRequestId = "batch-1",
            Status = "COMPLETED",
            CreationDate = created.ToUnixTimeMilliseconds(),
            Items =
            [
                new BatchRequestResultModel.Item
                {
                    Status = "FAILED",
                    FailureReasons = ["Barkod geçersiz"],
                    RequestItem = new BatchRequestResultModel.RequestItem
                    {
                        Product = new ProductRequestModel { Items = [new ProductModel { Barcode = "A", ProductMainId = "1" }] }
                    }
                }
            ]
        };

        var dto = _adapter.Adapt<TrendyolBatchRequestResultDTO>(model);

        dto.BatchRequestId.ShouldBe("batch-1");
        dto.CreationDate.ToUniversalTime().ShouldBe(created.UtcDateTime);
        var item = dto.Items.ShouldHaveSingleItem();
        item.FailureReasons.ShouldBe(["Barkod geçersiz"]);
        item.RequestItem.ShouldHaveSingleItem().Barcode.ShouldBe("A");
    }

    [Fact]
    public void Adapt_maps_error_result()
    {
        var model = new ErrorResultModel
        {
            Timestamp = 1,
            Exception = "ValidationException",
            Errors = [new ErrorResultModel.ErrorModel { Key = "barcode", Message = "Zorunlu", Args = ["x"] }]
        };

        var dto = _adapter.Adapt<TrendyolErrorResultDTO>(model);

        dto.Exception.ShouldBe("ValidationException");
        var error = dto.Errors.ShouldHaveSingleItem();
        error.Key.ShouldBe("barcode");
        error.Args.ShouldBe(["x"]);
    }
}
