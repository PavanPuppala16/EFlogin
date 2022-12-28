using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFlogin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "email is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}