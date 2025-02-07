namespace ECommerce.Trendyol.Order
{
    public class UpdatePackageRequestDto
    {
        public List<Line> Lines { get; set; }
        public ParamsModel Params { get; set; }
        public string Status { get; set; }

        public class Line
        {
            public string LineId { get; set; }
            public int Quantity { get; set; }
        }

        public class ParamsModel
        {
            public string InvoiceNumber { get; set; }
        }
    }
}
