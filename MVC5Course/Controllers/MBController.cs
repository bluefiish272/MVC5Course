using MVC5Course.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class MBController : BaseController
    {
        // GET: MB
        public ActionResult Index()
        {
            ViewData["Temp1"] = "暫存資料1";

            var o = new ClientLoginViewModel()
            {
                FirstName = "Lucky",
                LastName = "Yen"
            };

            ViewData["Temp2"] = o;

            ViewBag.Temp3 = o;

            return View();
        }

        public ActionResult MyForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MyForm(ClientLoginViewModel c)
        {
            if (ModelState.IsValid)
            {
                TempData["MyFormData"] = c;
                return Redirect("MyFormResult");
            }
            return View();
        }

        public ActionResult MyFormResult()
        {
            return View();
        }

        public ActionResult ProductList()
        {
            var data = db.Product.OrderBy(p => p.ProductId).Take(10);
            return View(data);
        }

        public ActionResult BatchUpdate(BatchUpadeViewModel[] items)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in items)
                {
                    var data = db.Product.Find(item.ProductId);
                    data.ProductName = item.ProductName;
                    data.Active = item.Active;
                    data.Stock = item.Stock;
                    data.Price = item.Price;
                }
                db.SaveChanges();
            }
            return RedirectToAction("ProductList");
        }
    }
}