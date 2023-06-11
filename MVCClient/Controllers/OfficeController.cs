using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVCClient.Controllers
{
   public class OfficeController : Controller
   {
      [AllowAnonymous]
      public IActionResult Index()
      {
         return View();
      }
   }
}
