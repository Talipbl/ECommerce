using static Trendyol.Client.GetProductsResponseModel;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ECommerce.Trendyol;

namespace Ecommerce.Trendyol
{
    public class ProductVM
    {
        public string Barcode { get; set; }
        public string Brand { get; set; }
        public string CategoryName { get; set; }
        public object CreateDateTime { get; set; }
        public string Description { get; set; }
        public bool HasActiveCampaign { get; set; }
        public string Id { get; set; }
        public string ImageUrl { get; set; }
        public object LastUpdateDate { get; set; }
        public double ListPrice { get; set; }
        public int ProductCode { get; set; }
        public int ProductContentId { get; set; }
        public string ProductMainId { get; set; }
        public int Quantity { get; set; }
        public double SalePrice { get; set; }
        public string StockCode { get; set; }
        public string StockUnitType { get; set; }
        public int SupplierId { get; set; }
        public string Title { get; set; }
        public bool OnSale { get; set; }
        public string Status { get; set; }
        public bool Rejected { get; set; }
        public List<object> RejectReasonDetails { get; set; }
        public int? DeliveryDuration { get; set; }

        internal static ProductVM GetProductVM(ProductsResponseDTO.ContentDTO pr)
        {
            return new ProductVM()
            {
                Id = pr.Id,
                ProductMainId = pr.ProductMainId,
                Barcode = pr.Barcode,
                StockCode = pr.StockCode,
                ProductCode = pr.ProductCode,
                Title = pr.Title,
                Description = pr.Description,
                Brand = pr.Brand,
                CategoryName = pr.CategoryName,
                ImageUrl = pr.Images.FirstOrDefault(),
                CreateDateTime = pr.CreateDateTime,
                LastUpdateDate = pr.LastUpdateDate,
                ListPrice = pr.ListPrice,
                SalePrice = pr.SalePrice,
                DeliveryDuration = pr.DeliveryDuration,
                StockUnitType = pr.StockUnitType,
                ProductContentId = pr.ProductContentId,
                Quantity = pr.Quantity,
                SupplierId = pr.SupplierId,
                OnSale = pr.OnSale,
                Status = ResolveStatus(pr),
                Rejected = pr.Rejected,
                RejectReasonDetails = pr.RejectReasonDetails,
                HasActiveCampaign = pr.HasActiveCampaign
            };
        }

        private static string ResolveStatus(ProductsResponseDTO.ContentDTO pr)
        {
            var statusPriorities = new List<(bool statusOption, string status, int priority)>
            {
                (pr.Rejected, "Reddedildi", 1),
                (pr.Locked, "Kilitli", 2),
                (pr.Blacklisted, "Kara Listede", 4),
                (pr.Archived, "Arşivlendi", 3),
                (pr.OnSale, "Satışa Açık", 5),
                (!pr.OnSale, "Satışa Kapalı", 6)
            };

            return statusPriorities.OrderBy(x => x.priority).Where(x => x.statusOption).FirstOrDefault().status;
        }
    }
}
