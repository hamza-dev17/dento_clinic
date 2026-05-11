using System.Collections.Generic;

namespace Dento_Clinic.Models.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalPatients { get; set; }
        public int ActiveTreatments { get; set; }
        public int AppointmentsToday { get; set; }
        public decimal PendingPayments { get; set; }
        
        public List<RecentActivityViewModel> RecentActivities { get; set; }
    }

    public class RecentActivityViewModel
    {
        public string Activity { get; set; } // Description of the activity
        public string TimeAgo { get; set; } // Human-readable time
        public string BadgeClass { get; set; } // Bootstrap class for badges
    }
}
