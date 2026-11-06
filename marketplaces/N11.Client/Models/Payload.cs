using Newtonsoft.Json;

namespace N11.Client
{
    public class Payload
    {
        public string Integrator { get; set; }
        public List<StockItem> Skus { get; set; }
    }
}
