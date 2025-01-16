namespace N11.Client
{
    public class GetProductsResponse : Pagination
    {
        public ProductBasicModel[] Products { get; set; }
    }
}
