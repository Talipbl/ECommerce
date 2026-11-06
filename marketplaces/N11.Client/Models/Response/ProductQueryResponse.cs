using Newtonsoft.Json;

namespace N11.Client.Models.Response
{
    public class ProductQueryResponse
    {
        [JsonProperty("content")]
        public List<Product> Content { get; set; }

        [JsonProperty("pageable")]
        public Pageable Pageable { get; set; }

        [JsonProperty("last")]
        public bool Last { get; set; }

        [JsonProperty("totalElements")]
        public int TotalElements { get; set; }

        [JsonProperty("totalPages")]
        public int TotalPages { get; set; }

        [JsonProperty("first")]
        public bool First { get; set; }

        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("sort")]
        public object Sort { get; set; }

        [JsonProperty("numberOfElements")]
        public int NumberOfElements { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("empty")]
        public bool Empty { get; set; }
    }
}
