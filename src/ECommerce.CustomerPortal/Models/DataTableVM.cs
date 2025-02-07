namespace ECommerce.CustomerPortal.Models
{
    public class DataTableVM<T> where T : class, new()
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public List<T> data { get; set; }
    }
}
