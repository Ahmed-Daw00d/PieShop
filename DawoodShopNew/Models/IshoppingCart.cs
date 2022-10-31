namespace DawoodShopNew.Models
{
    public interface IshoppingCart
    {
        void AddToCart(Pie pie);
        int RemoveFromCart(Pie pie);

        List<ShoppingCartItem> GetShoppingCartItems();
        void ClearCart();
        decimal GetShoppingCartTotal();
        List<ShoppingCartItem> ShoppingCartItems { get; set; }

    }
}
