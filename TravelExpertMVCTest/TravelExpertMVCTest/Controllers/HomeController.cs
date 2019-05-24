using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelExpertMVCTest.Models;

namespace TravelExpertMVCTest.Controllers
{
    public class HomeController : Controller
    {
        private TravelExpertsEntities db = new TravelExpertsEntities();
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
        public ActionResult Packages()
        {
            List<Package> packageList = db.Packages.ToList();
            ViewBag.Message = "Your travel package page.";

            return View(packageList);
        }

        public ActionResult Customer_Packages()
        {
            if (Session["custId"] != null)
            {
                int custId = (int)Session["custId"];
                var packageList = db.Customers_Packages.Where(x => x.Customer.CustomerId == custId).ToList();
                ViewBag.Message = "Your travel package page.";

                return View(packageList);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult Buy(int id)
        {
            Customers_Packages custPkg = new Customers_Packages();
            if (Session["custId"] !=null)
            {
                int custId = (int)Session["custId"];
                custPkg.CustomerId = custId;
                custPkg.PackageId = id;
                db.Customers_Packages.Add(custPkg);
                db.SaveChangesAsync();
                return RedirectToAction("Customer_Packages", "Home");
            }
            else
            {  
                return RedirectToAction("Login", "Account");
            }
            
        }

        public ActionResult Remove(int id)
        {
            Customers_Packages custPkg = db.Customers_Packages.Find(id);
            db.Customers_Packages.Remove(custPkg);
            db.SaveChangesAsync();
            return RedirectToAction("Customer_Packages", "Home");
        }
    }
}