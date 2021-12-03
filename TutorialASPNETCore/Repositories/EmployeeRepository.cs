using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutorialASPNETCore.Models;

namespace TutorialASPNETCore.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employees;
        public EmployeeRepository()
        {
            _employees = new List<Employee>()
            {
                new Employee()
                {
                    id = 1,
                    email = "seba.zonta@gmail.com",
                    name = "seba",
                    Department = Department.IT
                },
                new Employee()
                {
                    id=2,
                    email="utn@rosariobus.com",
                    name="UTN",
                    Department = Department.HR
                }
            };

        }

        public Employee Add(Employee employee)
        {
            employee.id= _employees.Max(x => x.id) + 1;
            _employees.Add(employee);
            return employee;
        }

        public Employee getEmployee(int id)
        {
            return _employees.FirstOrDefault(e => e.id == id);   
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employees;
        }
    }
      
    
}
