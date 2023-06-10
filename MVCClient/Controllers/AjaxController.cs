using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVCClient.Controllers
{
   public class AjaxController : Controller
   {
      // GET: AjaxController
      public ActionResult Index()
      {
         return View();
      }

      // GET: AjaxController/Details/5
      public ActionResult Details(int id)
      {
         return View();
      }

      // GET: AjaxController/Create
      public ActionResult Create()
      {
         return View();
      }

      // POST: AjaxController/Create
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

      // GET: AjaxController/Edit/5
      public ActionResult Edit(int id)
      {
         return View();
      }

      // POST: AjaxController/Edit/5
      [HttpPost]
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

      // GET: AjaxController/Delete/5
      public ActionResult Delete(int id)
      {
         return View();
      }

      // POST: AjaxController/Delete/5
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
