namespace ECommerce.Application.DataTransferObjects.Category
{
    public class CategoryListModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }
        public string? ParentCategory { get; set; }
        public bool? IsParent { get; set; }
    }
}
