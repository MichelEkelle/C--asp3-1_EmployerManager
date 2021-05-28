using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Models
{
    public class EmployeeServices : IEmployeeServices
    {
        private List<Employee> _employeeList;
        public EmployeeServices()
        {
            _employeeList = new List<Employee>()
            {
                new Employee(){Id = 1, Name = "Michel", Email = "michel@logient.ca", Department = DeptEnum.NET },
                new Employee(){Id = 2, Name = "Adrien", Email = "adrien@logient.ca", Department = DeptEnum.NET },
                new Employee(){Id = 3, Name = "Sophie", Email = "sophie@logient.ca", Department = DeptEnum.NET },
                new Employee(){Id = 4, Name = "Aymen", Email =  "aymen@logient.ca", Department = DeptEnum.NET },
                new Employee(){Id = 5, Name = "Jerome", Email = "jerome@logient.ca", Department = DeptEnum.RH },
                new Employee(){Id = 6, Name = "Julie", Email = "julie@logient.ca", Department = DeptEnum.RH },
                new Employee(){Id = 7, Name = "samuel", Email = "samuel@logient.ca", Department = DeptEnum.JAVA },
                new Employee(){Id = 8, Name = "Eric", Email = "eric@logient.ca", Department = DeptEnum.JAVA },
                new Employee(){Id = 9, Name = "Felix", Email = "felix@logient.ca", Department = DeptEnum.JAVA }

            };

        }

        public Employee AddEmployee(Employee employee)
        {
            employee.Id = _employeeList.Count() + 1;
            _employeeList.Add(employee);
            return employee;
        }

        public Employee deleteEmployee(int id)
        {
            Employee removedEmployee = _employeeList.FirstOrDefault(e=>e.Id==id);
            if (removedEmployee != null)
            { 
                _employeeList.Remove(removedEmployee);
            } 
            return removedEmployee;
        }

        public List<Employee> GetAllEmployee()
        {
            return _employeeList; 
        }
        
        public Employee GetEmployee(int Id)
        {
           return  _employeeList.FirstOrDefault(epl => epl.Id == Id);
            
        }

        public Employee UpdateEmployee(Employee changeEmpl)
        {
            Employee newEmployee = _employeeList.FirstOrDefault(e => e.Id == changeEmpl.Id);
            if (newEmployee != null)
            {
                newEmployee.Name = changeEmpl.Name;
                newEmployee.Email = changeEmpl.Email;
                newEmployee.Department = changeEmpl.Department;
            }
            return newEmployee;
        }

        


    }
}
