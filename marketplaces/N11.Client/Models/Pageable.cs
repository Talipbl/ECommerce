using Newtonsoft.Json;

namespace N11.Client
{
    public class Pageable
    {
        [JsonProperty("sort")]
        public object Sort { get; set; }

        [JsonProperty("pageNumber")]
        public int PageNumber { get; set; }

        [JsonProperty("pageSize")]
        public int PageSize { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("paged")]
        public bool Paged { get; set; }

        [JsonProperty("unpaged")]
        public bool Unpaged { get; set; }
    }


}
