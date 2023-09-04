namespace ECommerce.AdminUI.Models
{
    public class CategoryModifyModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public int ParentId { get; set; }
        public bool IsParent { get; set; }
    }
}
