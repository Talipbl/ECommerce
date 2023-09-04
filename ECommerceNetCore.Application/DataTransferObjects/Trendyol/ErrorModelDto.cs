namespace ECommerce.Trendyol
{
    public class ErrorModelDto
    {
        public string Key { get; set; }
        public string Message { get; set; }
        public string ErrorCode { get; set; }
        public List<string> Args { get; set; }
    }
}
