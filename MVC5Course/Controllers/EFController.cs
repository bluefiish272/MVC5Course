using MVC5Course.Models;
using MVC5Course.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class EFController : Controller
    {
        FabricsEntities db = new FabricsEntities();

        // GET: EF
        public ActionResult Index()
        {
            var data = db.Product.Where(p => p.ProductName.StartsWith("White"));
            return View(data);
        }

        public ActionResult Create()
        {
            var product = new Product()
            {
                ProductName = "White Mark",
                Price = 19,
                Active = true,
                Stock = 1                
            };
            db.Product.Add(product);
           // db.SaveChanges();

            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityError in ex.EntityValidationErrors)
                {
                    foreach (var vErrors in entityError.ValidationErrors)
                    {
                        throw new DbEntityValidationException(vErrors.PropertyName + "發生錯誤：" + vErrors.ErrorMessage);

                    }
                }

            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var product = db.Product.Find(id);

            db.OrderLine.RemoveRange(product.OrderLine);
            db.Product.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var product = db.Product.Find(id);
            return View(product);
        }

        public ActionResult Update(int id)
        {
            var product = db.Product.Find(id);
            product.ProductName += "!";
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityError in ex.EntityValidationErrors)
                {
                    foreach (var vErrors in entityError.ValidationErrors)
                    {
                        throw new DbEntityValidationException(vErrors.PropertyName + "發生錯誤：" + vErrors.ErrorMessage);
                        
                    }
                }
                
            }
            return RedirectToAction("Index");

        }

        //public ActionResult Add20Percent()
        //{
        //    var data = db.Product.Where(p => p.ProductName.StartsWith("White"));

        //    foreach (var item in data)
        //    {
        //        item.Price = item.Price * 1.2m;
        //    }
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        public ActionResult Add20Percent()
        {
            string str = "White%";
            db.Database.ExecuteSqlCommand("UPDATE dbo.Product SET Price = Price*1.2 WHERE ProductName LIKE @p0", str);

            return RedirectToAction("Index");
        }

        public ActionResult ClientContribution()
        {
            var data = db.vw_ClientContribution.Take(10);
            return View(data);
        }

        public ActionResult ClientContribution2(string keyword = "Mary")
        {
            var data = db.Database.SqlQuery<ClientContributionViewModel>(@"
	SELECT
		 c.FirstName,
		 c.LastName,
		 (SELECT SUM(o.OrderTotal) 
		  FROM [dbo].[Order] o 
		  WHERE o.ClientId = c.ClientId) as OrderTotal
	FROM 
		[dbo].[Client] as c
    WHERE
        c.FirstName LIKE @p0", "%" + keyword + "%");
            return View(data);
        }

        public ActionResult ClientContribution3(string keyword = "Mark")
        {
            return View(db.usp_GetClientContribution(keyword));
        }
    }
}