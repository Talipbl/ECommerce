namespace N11.Client
{
    public class BaseResponse<TResponse ,TApiResponse>
    {
        public ClientResponse<TResponse> ClientResponse { get; set; }
        public TApiResponse ApiResponse { get; set; }
    }

    public class BaseResponse<TApiResponse>
    {
        public BaseClientResponse ClientResponse { get; set; }
        public TApiResponse ApiResponse { get; set; }
    }
}
