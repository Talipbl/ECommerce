namespace N11.Client
{
    public class Pagination : BaseResponse
    {
        public PagingData Paging { get; set; }

        public class PagingData
        {
            public int CurrentPage { get; set; }
            public int PageSize { get; set; }
            public int TotalCount { get; set; }
            public int PageCount { get; set; }
        }
    }
}
