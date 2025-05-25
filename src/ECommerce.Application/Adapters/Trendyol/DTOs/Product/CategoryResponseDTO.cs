namespace ECommerce.Trendyol
{
    public class CategoryResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public List<CategoryResponseDTO> SubCategories { get; set; }
    }
}
