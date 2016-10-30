using System;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ShareViewDataAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewData["Temp1"] = "暫存資料1";
        }
    }
}