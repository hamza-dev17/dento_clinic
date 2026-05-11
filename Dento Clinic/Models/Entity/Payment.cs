namespace Dento_Clinic.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        [Required(ErrorMessage = "*Appointment Time is required")]
        public Nullable<int> AppointmentId { get; set; }

        [Required(ErrorMessage = "*This field can not be empty")]
        [Range(0.01, double.MaxValue, ErrorMessage = "*Amount must be greater than 0")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "*Payment date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Payment Date")]
        public System.DateTime PaymentDate { get; set; }

        [Required(ErrorMessage = "*Status is required")]
        public string Status { get; set; }

        public virtual Appointment Appointment { get; set; }
    }
}
