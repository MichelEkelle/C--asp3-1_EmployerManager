using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Models
{
    public interface IEmployeeServices
    {
        Employee GetEmployee(int Id);
        List<Employee> GetAllEmployee();
        Employee AddEmployee(Employee employee);
        Employee deleteEmployee(int id);
        Employee UpdateEmployee(Employee employee);
        
    }
}
