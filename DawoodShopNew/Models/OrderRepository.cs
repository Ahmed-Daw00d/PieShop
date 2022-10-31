namespace DawoodShopNew.Models
{
    public class OrderRepository:IOrderRepository
    {
        private readonly IshoppingCart _shoppingCart;
        private readonly DawoodShopNewDbContext dawoodShopNewDbContext;

        public OrderRepository(IshoppingCart shoppingCart, DawoodShopNewDbContext dawoodShopNewDbContext)
        {
            _shoppingCart = shoppingCart;
            this.dawoodShopNewDbContext = dawoodShopNewDbContext;
        }

public void CreateOrder(Order order)
        {
           order.OrderPlaced=DateTime.Now;

            List<ShoppingCartItem> ShoppingCartItems=_shoppingCart.ShoppingCartItems;
            order.OrderTotal=_shoppingCart.GetShoppingCartTotal();
            order.OrderDetails = new List<OrderDetail>();
            foreach(ShoppingCartItem?shoppingCartItem in ShoppingCartItems)
            {
                var orderDetail = new OrderDetail { 
                Amount=shoppingCartItem.Amount,
                Price=shoppingCartItem.pie.Price,
                PieId=shoppingCartItem.pie.PieId
               };
                order.OrderDetails.Add(orderDetail);
            }
            dawoodShopNewDbContext.Orders.Add(order);
            dawoodShopNewDbContext.SaveChanges();
        }
    }
}
