using System;
using System.Net;
using System.Linq;
using Highway.Data;
using System.Web.Mvc;
using ogsysCRM.Models;
using ogsysCRM.Services;
using System.Data.Entity;
using System.Collections.Generic;

namespace ogsysCRM.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        CustomersService _customers;

        /// <summary>
        /// Initializes a new instance of the CustomerController class.
        /// </summary>
        /// <param name="customers"></param>
        public CustomerController(CustomersService customers)
        {
            _customers = customers;
        }

        // GET: /Customer/
        public ActionResult Index()
        {
            return View(_customers.GetAllCustomers());
        }

        // GET: /Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = _customers.GetCustomerById(id.Value);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: /Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,FirstName,LastName,AvatarUrl,CompanyName,EmailAddress,PhoneNumber")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customers.AddCustomer(customer);
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: /Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = _customers.GetCustomerById(id.Value);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: /Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,FirstName,LastName,AvatarUrl,CompanyName,EmailAddress,PhoneNumber")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customers.UpdateCustomer(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: /Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = _customers.GetCustomerById(id.Value);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: /Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = _customers.GetCustomerById(id);
            _customers.DeleteCustomer(customer);
            return RedirectToAction("Index");
        }
    }
}
