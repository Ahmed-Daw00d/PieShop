using Microsoft.EntityFrameworkCore;

namespace DawoodShopNew.Models
{
    public class ShoppingCart:IshoppingCart
    {
        private readonly DawoodShopNewDbContext _dawoodShopNewDbContext;
        public string? ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;
        public ShoppingCart(DawoodShopNewDbContext dawoodShopNewDbContext)
        {
            _dawoodShopNewDbContext = dawoodShopNewDbContext;
        }
        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

            DawoodShopNewDbContext context = services.GetService<DawoodShopNewDbContext>() ?? throw new Exception("Error initializing");

            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();

            session?.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Pie pie)
        {
            var ShoppingCartItem=_dawoodShopNewDbContext.ShoppingCartItems.FirstOrDefault(s=>s.pie.PieId==pie.PieId&&s.shoppingCartId==ShoppingCartId);

            if (ShoppingCartItem == null) {
                ShoppingCartItem = new ShoppingCartItem
                {
                shoppingCartId = ShoppingCartId,pie=pie,Amount=1
                };
                _dawoodShopNewDbContext.ShoppingCartItems.Add(ShoppingCartItem);
            }
            else { ShoppingCartItem.Amount++; }
            _dawoodShopNewDbContext.SaveChanges();
        }

        public int RemoveFromCart(Pie pie)
        {
            var shoppingCartItem =
                    _dawoodShopNewDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.pie.PieId == pie.PieId && s.shoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _dawoodShopNewDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _dawoodShopNewDbContext.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??=
                       _dawoodShopNewDbContext.ShoppingCartItems.Where(c => c.shoppingCartId == ShoppingCartId)
                           .Include(s => s.pie)
                           .ToList();
        }

        public void ClearCart()
        {
            var cartItems = _dawoodShopNewDbContext
                .ShoppingCartItems
                .Where(cart => cart.shoppingCartId == ShoppingCartId);

            _dawoodShopNewDbContext.ShoppingCartItems.RemoveRange(cartItems);

            _dawoodShopNewDbContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _dawoodShopNewDbContext.ShoppingCartItems.Where(c => c.shoppingCartId == ShoppingCartId)
                .Select(c => c.pie.Price * c.Amount).Sum();
            return total;
        }


    }
}
