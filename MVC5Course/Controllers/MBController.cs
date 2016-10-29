using MVC5Course.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class MBController : Controller
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
    }
}