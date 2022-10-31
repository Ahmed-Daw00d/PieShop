using DawoodShopNew.Models;
using DawoodShopNew.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DawoodShopNew.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly IshoppingCart _ishoppingCart;

        public ShoppingCartController(IPieRepository pieRepository, IshoppingCart ishoppingCart)
        {
            _pieRepository = pieRepository;
            _ishoppingCart = ishoppingCart;
        }



        public IActionResult Index()
        {
            var items = _ishoppingCart.GetShoppingCartItems();
            _ishoppingCart.ShoppingCartItems= items;
            var shoppingCartViewModel = new ShoppingCartViewModel(_ishoppingCart,_ishoppingCart.GetShoppingCartTotal());
            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int pieId)
        {
            var selectedPie = _pieRepository.AllPies.FirstOrDefault(p => p.PieId == pieId);

            if (selectedPie != null)
            {
                _ishoppingCart.AddToCart(selectedPie);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int pieId)
        {
            var selectedPie = _pieRepository.AllPies.FirstOrDefault(p => p.PieId == pieId);

            if (selectedPie != null)
            {
                _ishoppingCart.RemoveFromCart(selectedPie);
            }
            return RedirectToAction("Index");
        }
    }
}
