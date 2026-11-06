using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N11.Client
{
    public enum SaleStatus
    {
        /// <summary>
        /// Satışta
        /// </summary>
        On_Sale,

        /// <summary>
        /// Stokta Yok
        /// </summary>
        Out_Of_Stock
    }

    public enum ProductStatus
    {
        /// <summary>
        /// Onaylı
        /// </summary>
        Active,

        /// <summary>
        /// Katalog Onay Sürecinde
        /// </summary>
        InCatalogApproval,

        /// <summary>
        /// Beklemede
        /// </summary>
        Suspended,

        /// <summary>
        /// Katalogdan Reddedildi
        /// </summary>
        CatalogRejected,

        /// <summary>
        /// Yasaklı
        /// </summary>
        Prohibited,

        /// <summary>
        /// Limit Dışı
        /// </summary>
        Unlisted
    }

    public enum OrderStatus
    {
        Created,
        Picking,
        Shipped,
        Cancelled,
        Delivered,
        Unpacked,
        UnSupplied
    }

    public enum OrderByDirection
    {
        ASC,
        DESC
    }
}
