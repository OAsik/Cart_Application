using Cart_Administration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cart_Administration.Controllers
{
    public class HomeController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Employees obj)
        {
            string gidilecekSayfa = "Login";
            bool validUser = false;
            string userName = obj.FirstName;
            string password = obj.LastName;
            string remember = Request.Form["Remember"];
            Employees employee = db.Employees.FirstOrDefault(x => x.FirstName == userName && x.LastName == password);

            if (employee == null)
            {
                validUser = false;
                TempData["loginError"] = "Please check your username and password.";
            }
            else
            {
                validUser = true;
                TempData["loginError"] = "";
                Session["userName"] = employee.FirstName.ToString();

                //if (remember != null && remember == "Remember")
                //{
                //    Cookie codes
                //}
            }

            if (validUser == true)
            {
                gidilecekSayfa = "Index";
            }

            return RedirectToAction(gidilecekSayfa);
        }

        public ActionResult Index()
        {
            if (Session["userName"] == null || Session["userName"].ToString() == "")
            {
                return RedirectToAction("Login");
            }
            else
            {
                List<Categories> categories = db.Categories.ToList();
                return View(categories);
            }            
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}