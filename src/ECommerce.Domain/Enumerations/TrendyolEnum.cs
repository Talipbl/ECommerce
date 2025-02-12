using System.ComponentModel;

namespace ECommerce.Trendyol
{
    /// <summary>
    /// Sipariş Tedarik Edememe Nedenleri
    /// </summary>
    public enum FailureToSupplyReason
    {
        /// <summary>
        /// Ürünün stoğu tükenmesi ve gönderimin gecikmesi gibi sebeplerle tedarik edilememesi durumunda seçilmelidir.
        /// </summary>
        [Description("Ürünün stoğu tükenmesi ve gönderimin gecikmesi gibi sebeplerle tedarik edilememesi durumunda seçilmelidir.")]
        StockDepleted = 500,

        /// <summary>
        /// Ürün kusurlu/defolu/bozuk olduğu için gönderilememesi durumunda seçilmelidir.
        /// </summary>
        [Description("Ürün kusurlu/defolu/bozuk olduğu için gönderilememesi durumunda seçilmelidir.")]
        DefectiveProduct = 501,

        /// <summary>
        /// Yanlış fiyat beslenmesi durumunda seçilmelidir.
        /// </summary>
        [Description("Yanlış fiyat beslenmesi durumunda seçilmelidir.")]
        IncorrectPrice = 502,

        /// <summary>
        /// Entegrasyon firmasından kaynaklı olarak hatalı fiyat ya da stok aktarımında yaşanan sorunlarda seçilmelidir.
        /// </summary>
        [Description("Entegrasyon firmasından kaynaklı olarak hatalı fiyat ya da stok aktarımında yaşanan sorunlarda seçilmelidir.")]
        IntegrationError = 504,

        /// <summary>
        /// Üründe yapılan indirim sonrası tek bir üründen ve aynı müşteri tarafından toplu olarak satın alınması durumunda seçilmelidir.
        /// </summary>
        [Description("Üründe yapılan indirim sonrası tek bir üründen ve aynı müşteri tarafından toplu olarak satın alınması durumunda seçilmelidir.")]
        BulkPurchase = 505,

        /// <summary>
        /// Doğal afet, hastalık, cenaze vb. durumlarda seçilmelidir.
        /// </summary>
        [Description("Doğal afet, hastalık, cenaze vb. durumlarda seçilmelidir.")]
        ForceMajeure = 506
    }

    public enum PackageStatus
    {
        Picking,
        Invoiced
    }

    /// <summary>
    /// Ürün sorgulama sırasında kullanılacak filtre
    /// </summary>
    public enum QueryOption
    {
        False,
        True,
        All
    }

    public enum DateType
    {
        CREATED_DATE,
        LAST_MODIFIED_DATE
    }
}
