using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Application.DataTransferObjects
{
    public class ProductPriceDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OptionId { get; set; }
        public decimal Price { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal? DiscountPrice { get; set; }
        public decimal? DiscountRatio { get; set; }
        public DateTime? DiscountExpireDate { get; set; }
        public int? CurrencyId { get; set; }
        public int? VatRatioId { get; set; }
        public int StatusId { get; set; }
        public bool IsSale { get; set; }
    }
}
