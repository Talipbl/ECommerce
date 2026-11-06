namespace N11.Client
{
    public class RestResponse
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public List<string> Reasons { get; set; }
    }
}
