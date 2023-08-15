namespace ECommerceNetCore.Service.ExternalServices.APIs.TrendyolClient.Models.OrderModels
{
    public class NonProcurementNoticeReuqest
    {
        public NonProcurementNoticeReuqest(NonProcurementNoticeReuqest request)
        {
            Lines = request.Lines;
            ReasonId = request.ReasonId;
        }

        public List<Line> Lines { get; set; }
        public int ReasonId { get; set; }
        public class Line
        {
            public int LineId { get; set; }
            public int Quantity { get; set; }
        }
    }

}
