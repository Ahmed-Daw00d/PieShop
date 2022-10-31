using DawoodShopNew.Models;
using Microsoft.AspNetCore.Mvc;

namespace DawoodShopNew.Component
{
    public class CategoryMenu:ViewComponent
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoryMenu(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoriesRepository.AllCategories.OrderBy(c => c.NameCategory);
            return View(categories);
        }
    }
}
