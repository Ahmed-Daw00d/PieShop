namespace DawoodShopNew.Models
{
    public class CategoriesRepository:ICategoriesRepository
    {
        private readonly DawoodShopNewDbContext _dawoodShopNewDbContext;

        public CategoriesRepository(DawoodShopNewDbContext dawoodShopNewDbContext)
        {
            _dawoodShopNewDbContext = dawoodShopNewDbContext;
        }

        public IEnumerable<Category> AllCategories => _dawoodShopNewDbContext.Categories.OrderBy(c => c.NameCategory);

       
    }
}
