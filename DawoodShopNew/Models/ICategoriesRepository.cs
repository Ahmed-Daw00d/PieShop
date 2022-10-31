namespace DawoodShopNew.Models
{
    public interface ICategoriesRepository
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
