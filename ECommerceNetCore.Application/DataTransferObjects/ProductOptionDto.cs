using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Application.DataTransferObjects
{
    public class ProductOptionDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string OptionName { get; set; }
        public string? StockCode { get; set; }
        public decimal? UnitOfStock { get; set; }
        public int UnitTypeId { get; set; }
        public decimal? Length { get; set; }
        public decimal? Height { get; set; }
        public decimal? Width { get; set; }
        public decimal? Weight { get; set; }
        public int? LengthTypeId { get; set; }
        public int StatusId { get; set; }
        public List<ProductImageDto> ProductImages { get; set; }
        public ProductPriceDto ProductPrice { get; set; }
    }
}
