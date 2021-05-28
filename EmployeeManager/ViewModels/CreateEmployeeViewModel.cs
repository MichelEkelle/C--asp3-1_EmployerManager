using EmployeeManager.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.ViewModels
{
    public class CreateEmployeeViewModel
    {
        public Employee EmployeeModel { get; set; }
        public IFormFile Photo { get; set; }
    }
}
