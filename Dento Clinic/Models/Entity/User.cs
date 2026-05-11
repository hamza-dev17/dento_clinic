using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dento_Clinic.Models.Entity
{
    public partial class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "*Username is required.")]
        [StringLength(50, ErrorMessage = "*Username cannot exceed 50 characters.")]
        [DisplayName("UserName")]
        public string Name { get; set; }

        [Required(ErrorMessage = "*Email is required.")]
        [EmailAddress(ErrorMessage = "*Invalid email format.")]
        [StringLength(100, ErrorMessage = "*Email cannot exceed 100 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*Password is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "*Password must be between 3 and 20 characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "*Please confirm your password.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "*Passwords do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "*Role is required.")]
        public string Role { get; set; }
    }
}
