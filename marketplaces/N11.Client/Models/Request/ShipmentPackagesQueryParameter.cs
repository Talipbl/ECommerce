namespace N11.Client
{
    public class ShipmentPackagesQueryParameter
    {
        /// <summary>
        /// Belirtilen tarihten sonraki siparişleri getirir. Timestamp (milliseconds) ve GMT+3 olarak gönderilmelidir.
        /// </summary>
        public long? StartDate { get; set; }

        /// <summary>
        /// Belirtilen tarihe kadar olan siparişleri getirir. Timestamp (milliseconds) ve GMT+3 olarak gönderilmelidir.
        /// </summary>
        public long? EndDate { get; set; }

        /// <summary>
        /// Sadece belirtilen sayfadaki bilgileri döndürür.
        /// </summary>
        public int Page { get; set; } = 0;

        /// <summary>
        /// Bir sayfada listelenecek maksimum adeti belirtir. Maksimum 100.
        /// </summary>
        public int Size { get; set; } = 20;

        /// <summary>
        /// Sipariş numarası ile sorgulama yapılır.
        /// </summary>
        public string? OrderNumber { get; set; }

        /// <summary>
        /// Paket numarası ile sorgulama yapılır.
        /// </summary>
        public string? PackageIds { get; set; }

        /// <summary>
        /// Belirtilen statülere göre siparişleri getirir.
        /// </summary>
        public OrderStatus? Status { get; set; }

        /// <summary>
        /// Siparişlerin sıralanma yönü. ASC: Eskiden yeniye, DESC: Yeniden eskiye.
        /// </summary>
        public OrderByDirection? OrderByDirection { get; set; }

        /// <summary>
        /// true girilirse paketin lastModifiedDate alanına göre sıralama yapılır.
        /// </summary>
        public bool? OrderByField { get; set; }
    }
}
