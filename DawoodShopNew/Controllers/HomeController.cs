using DawoodShopNew.Models;
using DawoodShopNew.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace DawoodShopNew.Controllers
{
    public class HomeController : Controller
    {


        private readonly IPieRepository pieRepository;
       

        public HomeController(IPieRepository pieRepository)
        {
            this.pieRepository = pieRepository;
            
        }

        public ViewResult Index()
        {
            var piesOfTheWeek = pieRepository.PiesOfTheWeek;
            var homeViewModel = new HomeViewModel(piesOfTheWeek);
            return View(homeViewModel);
        }

      
    }
}