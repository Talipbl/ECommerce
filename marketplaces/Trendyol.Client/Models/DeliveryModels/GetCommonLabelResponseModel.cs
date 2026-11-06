namespace Trendyol.Client
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
