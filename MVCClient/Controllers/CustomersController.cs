using Microsoft.AspNetCore.Mvc;

namespace MVCClient.Controllers
{
   public class CustomersController : Controller
   {
      public IActionResult Index()
      {
         return View();
      }
      public IActionResult CustomerInfo()
      {
         return View();
      }
   }
}
