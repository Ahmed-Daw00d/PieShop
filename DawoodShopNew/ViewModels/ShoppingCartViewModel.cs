using DawoodShopNew.Models;

namespace DawoodShopNew.ViewModels
{
    public class ShoppingCartViewModel
    {
       public IshoppingCart shoppingCart { get; }
        public decimal ShoppingCartTotal { get; }

        public ShoppingCartViewModel(IshoppingCart shoppingCart, decimal shoppingCartTotal)
        {
            this.shoppingCart = shoppingCart;
            ShoppingCartTotal = shoppingCartTotal;
        }
    }
}
