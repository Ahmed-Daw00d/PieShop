namespace DawoodShopNew.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public int Amount { get; set; }

        public Pie pie { get; set; } = default!;

        public string ? shoppingCartId { get; set; }

    }
}
