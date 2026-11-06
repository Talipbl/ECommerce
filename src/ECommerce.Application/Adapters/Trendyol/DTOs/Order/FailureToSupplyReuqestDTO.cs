using Trendyol.Client;

namespace ECommerce.Trendyol;
public class FailureToSupplyReuqestDTO
{
    public string PackageId { get; set; }
    public List<Line> Lines { get; set; }
    public FailureToSupplyReason Reason { get; set; }

    public class Line
    {
        public int LineId { get; set; }
        public int Quantity { get; set; }
    }
}
