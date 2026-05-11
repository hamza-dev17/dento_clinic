using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dento_Clinic.Models.Entity;

namespace Dento_Clinic.Controllers
{
    public class DentistsController : Controller
    {
        private DentalClinicDBEntities db = new DentalClinicDBEntities();

        // GET: Dentists
        public ActionResult Index()
        {
            return View(db.Dentists.ToList());
        }

        // GET: Dentists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dentists/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DentistId,Name,Specialization,Phone,Email")] Dentist dentist)
        {
            if (ModelState.IsValid)
            {
                db.Dentists.Add(dentist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dentist);
        }

        // GET: Dentists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Dentist dentist = db.Dentists.Find(id);
            if (dentist == null)
            {
                return HttpNotFound();
            }

            return View(dentist);
        }

        // POST: Dentists/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DentistId,Name,Specialization,Phone,Email")] Dentist dentist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dentist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dentist);
        }

        // GET: Dentists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Dentist dentist = db.Dentists.Find(id);
            if (dentist == null)
            {
                return HttpNotFound();
            }

            return View(dentist);
        }

        // POST: Dentists/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int DentistId)
        {
            var dentist = db.Dentists.Find(DentistId);
            if (dentist == null)
            {
                return HttpNotFound();
            }

            db.Dentists.Remove(dentist);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
