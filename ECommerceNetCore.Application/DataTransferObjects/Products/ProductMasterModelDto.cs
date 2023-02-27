using ECommerceNetCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Application.DataTransferObjects
{
    public class ProductMasterModelDto
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = null!;
        public int? ManufacturerId { get; set; }
        public string? Upc { get; set; }
        public string? Ean { get; set; }
        public string? Jan { get; set; }
        public string? Isbn { get; set; }
        public string? Mpn { get; set; }
        public int MinimumOrder { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int StatusId { get; set; }
        public int? XmlId { get; set; }
        public string? SellerCode { get; set; }
        public string? SellerUrl { get; set; }
        public string? StockCode { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public List<ProductOptionDto> ProductOptions { get; set; }
    }
}
