using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required, MaxLength(40)]
        public string Name { get; set; }

        [Display(Name="Office Email")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@logient.ca",ErrorMessage ="invalid email format: abc@logient.ca")]
        [Required]
        public string Email { get; set; }

        [Required]
        public DeptEnum? Department { get; set; }

        public string Photopath { get; set; }
    }
}
