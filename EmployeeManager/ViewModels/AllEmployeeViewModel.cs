using EmployeeManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.ViewModels
{
    public class AllEmployeeViewModel
    {
        public List<Employee> EmployeeListModel { get; set; }
        public string PageTitle  { get; set; }
    }
}
