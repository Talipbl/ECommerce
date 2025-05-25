namespace N11.Client
{
    public class ClientResponse<TResponse> : BaseClientResponse
    {
        public TResponse Data { get; set; }
        public PagingData Pagination { get; set; }
    }

    public class PagingData
    {
        public int? CurrentPage { get; set; }
        public int? PageSize { get; set; }
        public long? TotalCount { get; set; }
        public int? PageCount { get; set; }
    }
}
