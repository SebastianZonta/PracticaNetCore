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
                    name = "seba"
                },
                new Employee()
                {
                    id=2,
                    email="utn@rosariobus.com",
                    name="UTN"
                }
            };

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
