namespace ECommerceNetCore.Service.ExternalServices.APIs.TrendyolClient.Models.OrderModels
{
    public class UpdateBoxInfoRequest
    {
        public UpdateBoxInfoRequest(UpdateBoxInfoRequest request)
        {
            BoxQuantity = request.BoxQuantity;
            Deci = request.Deci;
        }

        public int BoxQuantity { get; set; }
        public double Deci { get; set; }
    }

}
