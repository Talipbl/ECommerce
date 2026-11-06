
namespace ECommerce.CustomerPortal.Models
{
    public class DataTableRequestVM
    {
        public int Draw { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
        public int Status { get; set; }
        public string Barcode { get; set; }
        public string StockCode { get; set; }
        public string ColumnName { get; set; }
        public string Direction { get; set; }

        public List<DataTableColumn> Columns { get; set; }
        public DataTableOrder Order { get; set; }
        public DataTableSearch Search { get; set; }

        public int GetStartPage() => (Start / Length);
    }

    public class DataTableColumn
    {
        public string Data { get; set; }
        public string Name { get; set; }
        public bool Searchable { get; set; }
        public bool Orderable { get; set; }
        public DataTableSearch Search { get; set; }
    }

    public class DataTableOrder
    {
        public int Column { get; set; }
        public string Dir { get; set; }
        public string Name { get; set; }
    }

    public class DataTableSearch
    {
        public string Value { get; set; }
        public bool Regex { get; set; }
    }
}
