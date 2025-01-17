namespace N11.Client
{
    public class BaseClientResponse<TResponse>
    {
        public bool Status { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public PagingData Pagination { get; set; }
        public TResponse Data { get; set; }
    }

    public class PagingData
    {
        public int? CurrentPage { get; set; }
        public int? PageSize { get; set; }
        public long? TotalCount { get; set; }
        public int? PageCount { get; set; }
    }
}
