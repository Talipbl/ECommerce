namespace N11.Client
{
    public class TaskDetailsResponse
    {
        public int TaskId { get; set; }
        public SkuList Skus { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string Status { get; set; }

        public class Sku
        {
            public double SalePrice { get; set; }
            public double ListPrice { get; set; }
            public string CurrencyType { get; set; }
            public List<string> Reasons { get; set; }
            public int Stock { get; set; }
        }

        public class SkuList
        {
            public List<Content> Content { get; set; }
            public Pageable Pageable { get; set; }
            public bool Last { get; set; }
            public int TotalElements { get; set; }
            public int TotalPages { get; set; }
            public Sort Sort { get; set; }
            public bool First { get; set; }
            public int Number { get; set; }
            public int NumberOfElements { get; set; }
            public int Size { get; set; }
            public bool Empty { get; set; }
        }

        public class Sort
        {
            public bool Empty { get; set; }
            public bool Sorted { get; set; }
            public bool Unsorted { get; set; }
        }

        public class Content
        {
            public int Id { get; set; }
            public int TaskId { get; set; }
            public int OwnerId { get; set; }
            public string ItemCode { get; set; }
            public string Status { get; set; }
            public Sku Sku { get; set; }
            public List<string> Reasons { get; set; }
        }
    }

    
}
