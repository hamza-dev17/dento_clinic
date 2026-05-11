using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dento_Clinic.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "*Username is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "*Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

