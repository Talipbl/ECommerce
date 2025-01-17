namespace N11.Client
{
    public class BaseResponse<TResponse ,TApiResponse>
    {
        public BaseClientResponse<TResponse> ClientResponse { get; set; }
        public TApiResponse ApiResponse { get; set; }
    }
}
