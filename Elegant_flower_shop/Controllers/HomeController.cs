using Elegant_flower_shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Elegant_flower_shop.Controllers
{
    public class HomeController : Controller
    {
        elegant_flower_shopEntities1 db = new elegant_flower_shopEntities1();
        public ActionResult Index()
        {
            return View();
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
        public ActionResult tableShow()
        {
            List<Customer> cd = db.Customers.ToList();
            return View(cd);
        }

        public ActionResult LoginPage()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult LoginPage(Customer customer)
        {
            ViewBag.Message = "Your contact page.";
            Customer ad = db.Customers.Where(temp => temp.customerName == customer.customerName && temp.customerPassword == customer.customerPassword).SingleOrDefault();
            if(ad!=null)
            {
                return RedirectToAction("Index","Home");
            }
            return View();
        }
        public ActionResult CreateUser()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult CreateUser(Customer customer)
        {
            if(ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            


            return View();
        }
        public ActionResult DeleteUser()
        {

            ViewBag.users = db.Customers.ToList();

            return View();
        }

        [HttpPost]
        public ActionResult DeleteUser(int UserID)
        {

            Customer user = db.Customers.Where(temp => temp.customer_id == UserID).FirstOrDefault();
            db.Customers.Remove(user);
            db.SaveChanges();
            ViewBag.users = db.Customers.ToList();

            return View();
        }




    }
}