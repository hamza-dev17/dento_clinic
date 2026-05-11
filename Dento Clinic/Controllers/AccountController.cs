using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Dento_Clinic.Models.Entity;
using Dento_Clinic.Models.ViewModels;

namespace Dento_Clinic.Controllers
{
    public class AccountController : Controller
    {
        private readonly DentalClinicDBEntities db = new DentalClinicDBEntities();

        // Registration (GET)
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        // Registration (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                // Check if username or email already exists
                var existingUser = db.Users.FirstOrDefault(u => u.Name == user.Name || u.Email == user.Email);

                if (existingUser == null)
                {
                    // Save the user to the database
                    db.Users.Add(user);
                    db.SaveChanges();

                    TempData["Success"] = "Registration successful! Please log in.";
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Email already exists.");
                }
            }
            return View(user);
        }

        // Login (GET)
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // Login (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                // Check for valid username and password in the database
                var userInDB = db.Users.FirstOrDefault(u => u.Name == user.Name && u.Password == user.Password);

                if (userInDB != null)
                {
                    // Store UserId and Username in Session
                    Session["UserId"] = userInDB.UserId;
                    Session["UserName"] = userInDB.Name;

                    TempData["Welcome"] = $"Welcome, {userInDB.Name}!";
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Username or Password.");
                    return View(user);
                }
            }
            ModelState.AddModelError("", "Something Went Wrong.");
            return View(user);
        }

        // Logout
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

        // Dashboard
        public ActionResult Dashboard()
        {
            if (Session["UserId"] != null)
            {
                // Prepare the dashboard data
                var model = new DashboardViewModel
                {
                    TotalPatients = db.Patients.Count(), // Total number of patients

                    AppointmentsToday = db.Appointments.Count(a =>
                        DbFunctions.TruncateTime(a.AppointmentDate) == DbFunctions.TruncateTime(DateTime.Today)), // Today's appointments

                    // Pending payments where the status is "Pending"
                    PendingPayments = db.Payments
                        .Where(p => p.Status == "Pending") // Only payments with "Pending" status
                        .Sum(p => (decimal?)p.Amount) ?? 0, // Sum of pending payments

                    ActiveTreatments = db.Treatments.Count(t => db.Appointments
                                                             .Where(a => a.AppointmentId == t.AppointmentId)
                                                             .Select(a => a.Status)
                                                             .Contains("Pending")) // Active treatments
                };

                // Fetch the 5 most recent appointments for "Recent Activities"
                var recentAppointments = db.Appointments
                    .OrderByDescending(a => a.AppointmentDate)
                    .Take(5)
                    .ToList(); // Fetch data first

                // Perform in-memory formatting for recent activities
                model.RecentActivities = recentAppointments.Select(a => new RecentActivityViewModel
                {
                    Activity = $"Appointment with Patient #{a.PatientId} and Dentist #{a.DentistId}",
                    TimeAgo = GetTimeAgo(a.AppointmentDate), // Helper for "time ago"
                    BadgeClass = GetBadgeClass(a.AppointmentDate) // Helper for badge styling
                }).ToList();

                return View(model); // Pass the model to the view
            }

            return RedirectToAction("Login"); // Redirect to login if session is null
        }



        // Helper: Get time ago for recent activities
        private string GetTimeAgo(DateTime activityDate)
        {
            var timeSpan = DateTime.Now - activityDate;

            if (timeSpan.TotalMinutes < 1)
                return "Just now";
            if (timeSpan.TotalMinutes < 2)
                return "A minute ago"; // Slightly more natural phrasing
            if (timeSpan.TotalMinutes < 60)
                return $"{(int)timeSpan.TotalMinutes} minutes ago";
            if (timeSpan.TotalHours < 24)
                return $"{(int)timeSpan.TotalHours} hours ago";
            if (timeSpan.TotalDays < 7)
                return $"{(int)timeSpan.TotalDays} days ago";
            if (timeSpan.TotalDays < 30)
                return $"{(int)(timeSpan.TotalDays / 7)} weeks ago"; // Shows weeks if < 30 days

            return activityDate.ToString("MMM dd, yyyy"); // Return formatted date if older than 30 days
        }


        // Helper: Get badge class for recent activities
        private string GetBadgeClass(DateTime activityDate)
        {
            var timeSpan = DateTime.Now - activityDate;

            // Return different badge classes based on the time span
            if (timeSpan.TotalMinutes < 1)
                return "badge-info"; // Just now - light blue
            if (timeSpan.TotalMinutes < 60)
                return "badge-success"; // Minutes ago - green
            if (timeSpan.TotalHours < 24)
                return "badge-warning"; // Hours ago - yellow/orange
            if (timeSpan.TotalDays < 7)
                return "badge-secondary"; // Days ago - grey

            return "badge-secondary"; // Default badge style for older dates
        }







    }
}
