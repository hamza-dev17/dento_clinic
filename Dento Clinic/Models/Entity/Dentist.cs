using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dento_Clinic.Models.Entity
{
    public partial class Dentist
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dentist()
        {
            this.Appointments = new HashSet<Appointment>();
        }

        [Key]
        public int DentistId { get; set; }

        [Required(ErrorMessage = "*Dentist name is required.")]
        [StringLength(100, ErrorMessage = "*Dentist name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "*Specialization is required.")]
        public string Specialization { get; set; }

        [Required(ErrorMessage = "*Phone number is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "*Phone number must be a 10-digit number.")]
        [Phone(ErrorMessage = "*Enter valid phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "*Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
