namespace N11.Client
{
    public class ProductQueryParameter
    {
        /// <summary>
        /// N11 Ürün kodu ile listeleme.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Ürün grup kodu ile listeleme.
        /// </summary>
        public string? ProductMainId { get; set; }

        /// <summary>
        /// Satıcı ürün kodu ile listeleme.
        /// </summary>
        public string? StockCode { get; set; }

        /// <summary>
        /// Ürün satış durumuna göre listeleme.
        /// OnSale: Satışta, OutOfStock: Stokta Yok
        /// </summary>
        public SaleStatus? SaleStatus { get; set; }

        /// <summary>
        /// Ürün onay durumuna göre listeleme.
        /// Active: Onaylı, InCatalogApproval: Katalog Onay Sürecinde, Suspended: Beklemede,
        /// CatalogRejected: Katalogdan Reddedildi, Prohibited: Yasaklı, Unlisted: Limit Dışı
        /// </summary>
        public ProductStatus? ProductStatus { get; set; }

        /// <summary>
        /// Marka ismine göre listeleme.
        /// </summary>
        public string? BrandName { get; set; }

        /// <summary>
        /// Kategori ID bilgisi ile listeleme.
        /// </summary>
        public List<long> CategoryIds { get; set; } = new();

        /// <summary>
        /// Sayfalama için başlangıç indexi. Varsayılan: 0
        /// </summary>
        public int Page { get; set; } = 0;

        /// <summary>
        /// Sayfa başına ürün sayısı. Varsayılan: 20, Maksimum: 250
        /// </summary>
        public int Size { get; set; } = 20;
    }
}
