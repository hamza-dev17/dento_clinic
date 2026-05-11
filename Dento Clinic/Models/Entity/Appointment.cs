namespace Dento_Clinic.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Appointment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Appointment()
        {
            this.Payments = new HashSet<Payment>();
            this.Treatments = new HashSet<Treatment>();
        }

        [Key]
        public int AppointmentId { get; set; }

        [Required(ErrorMessage = "*Patient is required")]
        public Nullable<int> PatientId { get; set; }

        [Required(ErrorMessage = "*Dentist is required")]
        public Nullable<int> DentistId { get; set; }

        [Required(ErrorMessage = "*Appointment date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Appointment Date")]
        public System.DateTime AppointmentDate { get; set; }

        [Required(ErrorMessage = "*Appointment time is required")]
        [DataType(DataType.Time)]
        [Display(Name = "Appointment Time")]
        public System.TimeSpan AppointmentTime { get; set; }

        [Required(ErrorMessage = "*Status is required")]
        [StringLength(50, ErrorMessage = "Status length cannot exceed 50 characters")]
        public string Status { get; set; }

        public virtual Dentist Dentist { get; set; }
        public virtual Patient Patient { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Treatment> Treatments { get; set; }
    }
}
