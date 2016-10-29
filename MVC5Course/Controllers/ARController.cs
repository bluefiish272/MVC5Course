using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : BaseController
    {

        // GET: AR
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NotFound()
        {
            return View();
        }

        public ActionResult PartialViewTest()
        {
            return PartialView();
        }

        public ActionResult ComtentTest()
        {
            return Content("MVC5課程", "text/plain");
        }

        public ActionResult FileTest()
        {
            //C:\Users\user\Source\Repos\MVC5Course\MVC5Course\Content\Lucky.jpg
            var filepath = Server.MapPath("~/Content/Lucky.jpg");
            return File(filepath,"img/jpeg");
        }

        public ActionResult FileTest2()
        {
            //C:\Users\user\Source\Repos\MVC5Course\MVC5Course\Content\Lucky.jpg
            var filepath = Server.MapPath("~/Content/Lucky.jpg");
            return File(filepath, "img/jpeg","ShenYen.jpg");
        }

        public ActionResult JsonTest()
        {
            db.Configuration.LazyLoadingEnabled = false;
            //延遲載入，避免循環參考
            var data = db.Product.OrderByDescending(p => p.ProductId).Take(10);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}