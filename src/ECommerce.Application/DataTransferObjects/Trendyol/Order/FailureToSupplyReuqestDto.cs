using AutoMapper;
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

    public class ReasonResolver : IValueResolver<FailureToSupplyReuqestDTO, FailureToSupplyReuqest, int>
    {
        public int Resolve(FailureToSupplyReuqestDTO source, FailureToSupplyReuqest destination, int destMember, ResolutionContext context)
        {
            return (int)source.Reason;
        }
    }
}
