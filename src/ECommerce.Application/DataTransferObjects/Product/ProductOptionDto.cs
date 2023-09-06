using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Product
{
    public class ProductOptionDto
    {
        public int Id { get; set; }
        public string OptionName { get; set; }
        public string? StockCode { get; set; }
        public decimal? UnitOfStock { get; set; }
        public int UnitTypeId { get; set; }
        public decimal? Length { get; set; }
        public decimal? Height { get; set; }
        public decimal? Width { get; set; }
        public decimal? Weight { get; set; }
        public int StatusId { get; set; }
        public bool IsAvailable { get; set; }
        public string? AvailableDate { get; set; }
        public decimal Price { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal? DiscountPrice { get; set; }
        public decimal? DiscountRatio { get; set; }
        public string? DiscountExpireDate { get; set; }
        public int? CurrencyId { get; set; }
        public int? VatRatioId { get; set; }
        public bool IsSale { get; set; }
        public string[] ProductImages { get; set; }
    }
}
