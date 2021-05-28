using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Models
{
    public class SQLEmployeeServices : IEmployeeServices
    {
        private readonly EmplManagerDbContext _context;

        public SQLEmployeeServices(EmplManagerDbContext context)
        {
            _context = context;
        }
        public Employee AddEmployee(Employee employee)
        {
           _context.EmployeeDbSet.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public Employee deleteEmployee(int id)
        {
            Employee removedEmpl= _context.EmployeeDbSet.Find(id);
            if(removedEmpl != null) 
            {
                _context.EmployeeDbSet.Remove(removedEmpl);
                _context.SaveChanges();
            }
           
            return removedEmpl;
        }

        public List<Employee> GetAllEmployee()
        {
            List<Employee> employeeList = new List<Employee>();
             _context.EmployeeDbSet.ToList<Employee>().ForEach(e=> 
            {
                employeeList.Add(e);
            });
            return employeeList;
        }

        public Employee GetEmployee(int id)
        {
           return _context.EmployeeDbSet.Find(id);
        }

        public Employee UpdateEmployee(Employee ChangedEmpl)
        {
            var employee = _context.EmployeeDbSet.Attach(ChangedEmpl);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return ChangedEmpl;
        }
    }
}
