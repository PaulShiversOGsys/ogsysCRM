using Highway.Data;
using ogsysCRM.Models;
using ogsysCRM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ogsysCRM.Controllers
{
    public class HomeController : Controller
    {
        CRMService _customers = new CRMService(DependencyResolver.Current.GetService<IRepository>());
        public ActionResult Index()
        {
            IEnumerable<Customer> allCustomers = _customers.GetAllCustomers();
            return View(allCustomers);
        }

        public ActionResult About()
        {
            ViewBag.Message = "ogsysCRM";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Justin Patterson";

            return View();
        }
    }
}