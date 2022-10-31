using DawoodShopNew.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DawoodShopNew.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderRepository orderRepository;
        private readonly IshoppingCart ishoppingCart;

        public OrderController(IOrderRepository orderRepository, IshoppingCart ishoppingCart)
        {
            this.orderRepository = orderRepository;
            this.ishoppingCart = ishoppingCart;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order) {

            var Item = ishoppingCart.GetShoppingCartItems();
            ishoppingCart.ShoppingCartItems = Item;

            if (ishoppingCart.ShoppingCartItems.Count == 0) {
                ModelState.AddModelError("","your cart is empty, add some pies first");
            }
            if (ModelState.IsValid) {
                orderRepository.CreateOrder(order);
                ishoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }
            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order. You'll soon enjoy our delicious pies!😉👌";
            return View();
        }
    }
}
