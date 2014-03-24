using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ogsysCRM.Models;
using ogsysCRM.Services;

namespace ogsysCRM.Controllers
{
    public class NoteController : Controller
    {
        private readonly CustomersService _service;

        /// <summary>
        /// Initializes a new instance of the NoteController class.
        /// </summary>
        /// <param name="service"></param>
        public NoteController(CustomersService service)
        {
            _service = service;
        }

        // GET: /Note/
        public ActionResult Index([Bind(Prefix="id")]int customerId)
        {
            var customer = _service.GetCustomerById(customerId);

            if (customer != null)
            {
                return View(customer);
            }

            return HttpNotFound();
        }

        // GET: /Note/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = _service.NoteById(id.Value);
            if (note == null)
            {
                return HttpNotFound();
            }
            return View(note);
        }

        // GET: /Note/Create
        public ActionResult Create(int customerId)
        {
            return View();
        }

        // POST: /Note/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Note note, int customerId)
        {
            if (ModelState.IsValid)
            {
                var customer = _service.GetCustomerById(customerId);
                var user = _service.GetUserByUserName(User.Identity.Name);
                note.Customer = customer;
                note.User = user;
                _service.AddNote(note);
                return RedirectToAction("Index", new { id = customerId});
            }

            return View(note);
        }

        // GET: /Note/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = _service.NoteById(id.Value);
            if (note == null)
            {
                return HttpNotFound();
            }
            return View(note);
        }

        // POST: /Note/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Note note, int customerId)
        {
            if (ModelState.IsValid)
            {
                //Users can only update the body
                Note realNote = _service.NoteById(note.Id);
                realNote.Body = note.Body;

                _service.UpdateNote(realNote);
                return RedirectToAction("Index", new { id = customerId });
            }
            return View(note);
        }

        // GET: /Note/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = _service.NoteById(id.Value);
            if (note == null)
            {
                return HttpNotFound();
            }
            return View(note);
        }

        // POST: /Note/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int customerId)
        {
            _service.DeleteNoteById(id);
            return RedirectToAction("Index", new { id = customerId });
        }
    }
}
