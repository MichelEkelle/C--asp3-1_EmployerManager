using EmployeeManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.ViewModels
{
    public class RegisterViewModel
    {

        [Required]
        [EmailAddress]
        //[Display(Name = "Office Email")]
       // [RegularExpression(@"^[a-zA-Z0-9_.+-]+@logient.ca", ErrorMessage = "invalid email format: abc@logient.ca")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("PassWord", 
                 ErrorMessage ="The two password do not match")]
        public string ConfirPassWord { get; set; }


    }
}
