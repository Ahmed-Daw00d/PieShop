using Microsoft.AspNetCore.Mvc;

namespace DawoodShopNew.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
