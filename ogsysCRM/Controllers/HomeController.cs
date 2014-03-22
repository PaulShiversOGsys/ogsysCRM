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
        CustomersService _customers = new CustomersService(DependencyResolver.Current.GetService<IRepository>());
        public ActionResult Index()
        {
            IEnumerable<Customer> allCustomers = _customers.GetAllCustomers();
            return View(allCustomers);
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
    }
}