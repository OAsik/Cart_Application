using Cart_Administration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cart_Administration.Controllers
{
    public class CartController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        public ActionResult Index()
        {
            if (Session["userName"] == null || Session["userName"].ToString() == "")
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                return View();
            }
        }

        public JsonResult List()
        {
            if (Session["basket"] != null)
            {
                CartModel cart = Session["basket"] as CartModel;
                List<ProductModel> productList = cart.ProductList.Select(x => new ProductModel
                {
                    ID = x.ID,
                    ProductName = x.ProductName,
                    UnitPrice = x.UnitPrice,
                    Quantity = x.Quantity
                }).ToList();

                return Json(productList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Empty", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Add(int id)
        {
            Products product = db.Products.Find(id);
            ProductModel model = new ProductModel
            {
                ID = product.ProductID,
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice,
                Quantity = 1
            };

            if (Session["basket"] == null)
            {
                CartModel cart = new CartModel();
                cart.AddCart(model);
                Session["basket"] = cart;
            }
            else
            {
                CartModel cart = Session["basket"] as CartModel;
                cart.AddCart(model);
                Session["basket"] = cart;
            }

            return Json("");
        }

        public JsonResult Increase(int id)
        {
            CartModel cart = Session["basket"] as CartModel;
            cart.IncreaseCart(id);
            return Json("");
        }

        public JsonResult Decrease(int id)
        {
            if (Session["basket"] != null)
            {
                CartModel cart = Session["basket"] as CartModel;
                cart.DecreaseCart(id);
                Session["basket"] = cart;
            }

            return Json("");
        }

        public JsonResult Remove(int id)
        {
            CartModel cart = Session["basket"] as CartModel;
            cart.RemoveCart(id);
            return Json("");
        }
    }
}