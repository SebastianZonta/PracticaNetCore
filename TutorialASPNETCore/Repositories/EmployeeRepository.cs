using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutorialASPNETCore.Context;
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

        public void Delete(Employee employee)
        {
            _employees.Remove(employee);
        }

        public Employee getEmployee(int id)
        {
            return _employees.FirstOrDefault(e => e.id == id);   
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employees;
        }

        public Employee Update(Employee employee)
        {
            var emplo=_employees.Where(e=>e.id==employee.id).FirstOrDefault();
            employee.id= emplo.id;
            employee.email= emplo.email;
            employee.name= emplo.name;
            employee.Department= emplo.Department;
            TutorialContext context = new TutorialContext();
            var empleado=context.employees.Attach(employee);
            empleado.State = EntityState.Modified;
            return employee;
        }
    }
      
    
}
