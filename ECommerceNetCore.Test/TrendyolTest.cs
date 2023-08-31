using AutoMapper;
using ECommerceNetCore.Application.Services;
using Marketplace.Trendyol;
using static Marketplace.Trendyol.ProductModel;

namespace ECommerceNetCore.Test
{
    public class TrendyolTest
    {
        //TrendyolClient client = new TrendyolClient();

    //    [Fact]
    //    public async void Get_Products()
    //    {
    //        var result = await client.GetProductsAsync(1, 10);
    //    }

    //    [Fact]
    //    public async void Get_Supplier_Addresses()
    //    {
    //        var result = await client.GetSupplierAddressAsync();
    //    }

    //    [Fact]
    //    public async void Get_Category_Attributes()
    //    {
    //        var result = await client.GetCategoryAttributes(899);
    //    }

    //    [Fact]
    //    public async void Create_Product()
    //    {
    //        List<ProductModel> list = new List<ProductModel>();
    //        ProductModel model = new ProductModel()
    //        {
    //            Barcode = "bard4236897984651",
    //            Title = "testürünü2",
    //            ProductMainId = "3542dsad42344BTK",
    //            BrandId = 1791,
    //            CategoryId = 411,
    //            Quantity = 100,
    //            StockCode = "STK-345",
    //            DimensionalWeight = 2,
    //            Description = "Ürün açýklama bilgisi",
    //            CurrencyType = "TRY",
    //            ListPrice = 2250.99,
    //            SalePrice = 1120.99,
    //            VatRate = 20,
    //            CargoCompanyId = 10,
    //            DeliveryOption = new DeliveryOptionModel
    //            {
    //                DeliveryDuration = 1,
    //                FastDeliveryType = "FAST_DELIVERY"
    //            },
    //            Images = new List<ImageModel>
    //            {
    //                new ImageModel
    //                {
    //                    Url = "https://www.sampleadress/path/folder/image_1.jpg"
    //                }
    //            },
    //            Attributes = new List<RequestAttribute>
    //            {
    //                new RequestAttribute
    //                {
    //                    AttributeId = 47,
    //                    CustomAttributeValue = "Kýrmýzý"
    //                },
    //                new RequestAttribute
    //                {
    //                    AttributeId = 14,
    //                    AttributeValueId = 85
    //                },
    //                new RequestAttribute
    //                {
    //                    AttributeId = 346,
    //                    AttributeValueId = 4290
    //                }
    //            }
    //        };

    //        list.Add(model);
    //        await client.CreateProductsAsync(list);
    //    }

    //    [Fact]
    //    public async void Update_Prodcut()
    //    {
    //        var products = await client.GetProductsAsync(1, 1, QueryBooleanOption.All, QueryBooleanOption.False);
    //        var prod = products.OkResponse.Content.FirstOrDefault();

    //        List<ProductModel> list = new List<ProductModel>();
    //        List<RequestAttribute> attributes = new List<RequestAttribute>();

    //        prod.Attributes.ForEach(a =>
    //        {
    //            RequestAttribute requestAttribute = new RequestAttribute()
    //            {
    //                AttributeId = a.AttributeId,
    //                AttributeValueId = a.AttributeValueId ?? 0,
    //                CustomAttributeValue = a.AttributeValue
    //            };

    //            attributes.Add(requestAttribute);
    //        });

    //        ProductModel model = new ProductModel()
    //        {
    //            Barcode = prod.Barcode,
    //            Title = prod.Title + "-tsctest01",
    //            ProductMainId = prod.ProductMainId,
    //            BrandId = prod.BrandId,
    //            CategoryId = prod.PimCategoryId,
    //            StockCode = prod.StockCode + "-tsctest",
    //            Description = prod.Description,
    //            DeliveryOption = prod.DeliveryOptions,
    //            Images = prod.Images,
    //            VatRate = prod.VatRate,
    //            Attributes = attributes
    //        };

    //        list.Add(model);
    //        var result = await client.UpdateProductsAsync(list);
    //    }
    }
}