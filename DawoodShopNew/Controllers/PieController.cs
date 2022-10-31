using DawoodShopNew.Models;
using DawoodShopNew.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace DawoodShopNew.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _IPieRepository;
        private readonly ICategoriesRepository _ICategoriesRepository;

        public PieController(IPieRepository iPieRepository, ICategoriesRepository iCategoriesRepository)
        {
            _IPieRepository = iPieRepository;
            _ICategoriesRepository = iCategoriesRepository;
        }

        /* public IActionResult List()
         {
           PieListViewModel _pieListViewModel = new PieListViewModel("All Pies",_IPieRepository.AllPies);

             return View(_pieListViewModel);
         }*/

        public ViewResult List(string category)
        {
            IEnumerable<Pie> pies;
            string? currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                pies = _IPieRepository.AllPies.OrderBy(p => p.PieId);
                currentCategory = "All pies";
            }
            else
            {
                pies = _IPieRepository.AllPies.Where(p => p.Category.NameCategory == category)
                    .OrderBy(p => p.PieId);
                currentCategory = _ICategoriesRepository.AllCategories.FirstOrDefault(c => c.NameCategory == category)?.NameCategory;
            }


            return base.View(new PieListViewModel(titleHead: currentCategory, pies: pies));
        }

        public IActionResult Details(int id) {
            
           var pie= _IPieRepository.GetPieById(id);

            if (pie == null)
                return NotFound();
            return View(pie); }

        public IActionResult Search()
        {
            return View();
        }

    }
}
