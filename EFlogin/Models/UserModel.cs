using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFlogin.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        [Required(AllowEmptyStrings = false ,ErrorMessage ="Firstname is required")]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Lastname is required")]
        [Display(Name = "LastName")]
        public string LastName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Confirmpassword is required")]
        [Display(Name = "ConfirmPassword")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="password should matches")]
        public string ConfirmPassword { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "createdon is required")]
        [Display(Name = "CreatedOn")]
        public DateTime CreatedOn{ get; set; }
        public string  SuccessMessage { get; set; }
    }
}