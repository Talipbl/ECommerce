using Trendyol.Client;

namespace ECommerce.Trendyol;

public class UpdatePackageRequestDTO
{
    public string PackageId { get; set; }
    public List<Line> Lines { get; set; }
    public PackageStatus Status { get; set; }
    public string InvoiceNumber { get; set; }

    public class Line
    {
        public string LineId { get; set; }
        public int Quantity { get; set; }
    }
}
