using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVCClient.Controllers
{
   public class DemoController : Controller
   { 
      public ActionResult Index()
      {
         return View();
      }
       
      public ActionResult Details(int id)
      {
         return View();
      }
       
      public ActionResult Create()
      {
         return View();
      }
       
      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Create(IFormCollection collection)
      {
         try
         {
            return RedirectToAction(nameof(Index));
         }
         catch
         {
            return View();
         }
      }
       
      public ActionResult Edit(int id)
      {
         return View();
      } 
      [ValidateAntiForgeryToken]
      public ActionResult Edit(int id, IFormCollection collection)
      {
         try
         {
            return RedirectToAction(nameof(Index));
         }
         catch
         {
            return View();
         }
      }

      // GET: DemoController/Delete/5
      public ActionResult Delete(int id)
      {
         return View();
      }

      // POST: DemoController/Delete/5
      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Delete(int id, IFormCollection collection)
      {
         try
         {
            return RedirectToAction(nameof(Index));
         }
         catch
         {
            return View();
         }
      }
   }
}
