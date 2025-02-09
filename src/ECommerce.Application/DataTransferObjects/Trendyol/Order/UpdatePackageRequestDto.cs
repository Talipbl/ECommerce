using AutoMapper;
using Trendyol.Client;

namespace ECommerce.Trendyol;

public class UpdatePackageRequestDTO
{
    public List<Line> Lines { get; set; }
    public PackageStatus Status { get; set; }
    public string InvoiceNumber { get; set; }

    public class Line
    {
        public string LineId { get; set; }
        public int Quantity { get; set; }
    }

    public class StatusResolver : IValueResolver<UpdatePackageRequestDTO, UpdatePackageRequest, string>
    {
        public string Resolve(UpdatePackageRequestDTO source, UpdatePackageRequest destination, string destMember, ResolutionContext context)
        {
            return source.Status.ToString();
        }
    }
}
