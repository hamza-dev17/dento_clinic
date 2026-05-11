using System.Linq;
using System.Text;
using System.Web.Mvc;
using Dento_Clinic.Models.Entity;
using Dento_Clinic.Models.ViewModels;
using System.Data.Entity;

namespace Dento_Clinic.Controllers
{
    public class ReportsController : Controller
    {
        private readonly DentalClinicDBEntities db = new DentalClinicDBEntities();

        // GET: Reports/Index
        public ActionResult Index()
        {
            // Fetching the required data for reports
            var model = new ReportsViewModel
            {
                TotalPatients = db.Patients.Count(),
                TotalAppointments = db.Appointments.Count(),
                TotalTreatments = db.Treatments.Count(),
                TotalPayments = db.Payments.Sum(p => (decimal?)p.Amount) ?? 0,
                TotalPendingPayments = db.Payments.Where(p => p.Status == "Pending").Sum(p => (decimal?)p.Amount) ?? 0,
                RecentAppointments = db.Appointments
                    .OrderByDescending(a => a.AppointmentDate)
                    .Take(5)
                    .ToList()
            };

            return View(model);
        }

        // Action to Download Report as CSV
        public ActionResult DownloadReportAsCsv()
        {
            var appointments = db.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Dentist)
                .ToList();

            var csv = new StringBuilder();
            csv.AppendLine("AppointmentDate,Patient,Dentist,Status");

            foreach (var appointment in appointments)
            {
                var patientName = appointment.Patient?.Name ?? "Unknown";
                var dentistName = appointment.Dentist?.Name ?? "Unknown";
                var status = appointment.Status ?? "Unknown";

                csv.AppendLine($"{appointment.AppointmentDate},{patientName},{dentistName},{status}");
            }

            return File(Encoding.UTF8.GetBytes(csv.ToString()), "text/csv", "AppointmentsReport.csv");
        }

        // GET: Reports/Edit
        public ActionResult Edit()
        {
            return View();
        }
    }
}
