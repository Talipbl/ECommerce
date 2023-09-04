namespace ECommerce.Service.ExternalServices.TrendyolClient.Models.DeliveryModels
{
    public class GetCommonLabelResponseModel
    {
        public List<Datum> Data { get; set; }
        public class Datum
        {
            public string Label { get; set; }
            public string Format { get; set; }
        }
    }
}
