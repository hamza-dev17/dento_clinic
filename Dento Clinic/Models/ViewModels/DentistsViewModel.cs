using System;
using System.Collections.Generic;

namespace Dento_Clinic.Models.ViewModels
{
    public class DentistsViewModel
    {
        public int TotalDentists { get; set; }
        public int TotalPatients { get; set; }

        // Patient Details
        public string PatientName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
       

        // Appointment Details
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        

        // Optional: You can remove this property if you're using ViewBag for dentists dropdown
        // public IEnumerable<System.Web.Mvc.SelectListItem> Dentists { get; set; }
    }
}
