using Dento_Clinic.Models.Entity;
using Dento_Clinic.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dento_Clinic.Controllers
{
    public class WebsiteController : Controller
    {
        private DentalClinicDBEntities db = new DentalClinicDBEntities();

      
        public ActionResult Index()
        {
            var model = new DentistsViewModel
            {
                TotalDentists = db.Dentists.Count(), // Total number of dentists
                TotalPatients = db.Patients.Count(), // Total number of patients
            };
            ViewBag.DentistId = new SelectList(db.Dentists, "DentistId", "Name");
            return View(model);
        }


        public ActionResult About()
        {
            var model = new DentistsViewModel
            {
                TotalDentists = db.Dentists.Count(), // Total number of patients
                TotalPatients = db.Patients.Count(), // Total number of patients

            };
            return View(model);
        }
        public ActionResult Services()
        {
            var model = new DentistsViewModel
            {
                TotalDentists = db.Dentists.Count(), // Total number of patients
                TotalPatients = db.Patients.Count(), // Total number of patients

            };
            return View(model);
        }
  
        public ActionResult Contact()
        {
            return View();
        }

       
    }
}