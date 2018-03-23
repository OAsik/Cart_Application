using Cart_Administration.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cart_Administration.Controllers
{
    public class ProductController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        public ActionResult Index(int? id, int page = 1)
        {
            if (id == 0 || id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<Products> productList = db.Products.Where(x => x.CategoryID == id).ToList();
            return View(productList.ToPagedList(page, 5));
        }
    }
}