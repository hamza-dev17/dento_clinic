using Dento_Clinic.Models.Entity;
using System.Collections.Generic;

namespace Dento_Clinic.Models.ViewModels
{
    public class ReportsViewModel
    {
        public int TotalPatients { get; set; }
        public int TotalAppointments { get; set; }
        public int TotalTreatments { get; set; }
        public decimal TotalPayments { get; set; }
        public decimal TotalPendingPayments { get; set; }
        public List<Appointment> RecentAppointments { get; set; }
    }
}
