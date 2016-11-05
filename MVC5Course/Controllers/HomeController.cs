﻿using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC5Course.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetTime()
        {
            return Content(DateTime.Now.ToString());
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel login, string ReturnUrl)
        {

            if (ModelState.IsValid)
            {
                if (login.Email == "mark@123.com" && login.Password == "123")
                {
                    FormsAuthentication.RedirectFromLoginPage(login.Email, false);
                    return Redirect(ReturnUrl ?? "/");
                }
            }
            return View();
        }

        //public ActionResult 註冊()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult 註冊(List<LoginViewModel> 註冊)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var data = new List<LoginViewModel>();
        //        data.Add(new LoginViewModel() { 註冊.Email });
        //    }
        //    return View();
        //}
    }
}