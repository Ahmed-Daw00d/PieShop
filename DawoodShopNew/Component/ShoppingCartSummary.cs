using DawoodShopNew.Models;
using DawoodShopNew.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DawoodShopNew.Component
{
    public class ShoppingCartSummary:ViewComponent
    {
        private readonly IshoppingCart ishoppingCart;

        public ShoppingCartSummary(IshoppingCart ishoppingCart)
        {
            this.ishoppingCart = ishoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var item = ishoppingCart.GetShoppingCartItems();
            ishoppingCart.ShoppingCartItems = item;
            ShoppingCartViewModel shoppingCartViewModel=new ShoppingCartViewModel(ishoppingCart,ishoppingCart.GetShoppingCartTotal());
            return View(shoppingCartViewModel);
        }
    }
}
