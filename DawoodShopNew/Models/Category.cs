namespace DawoodShopNew.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string NameCategory { get; set; } = string.Empty;

        public string? Description { get; set; }
        public List<Pie>? Pie { get; set; }
    }
}
