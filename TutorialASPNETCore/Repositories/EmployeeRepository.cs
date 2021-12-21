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
        private readonly TutorialContext context;
        private List<Employee> _employees;
        public EmployeeRepository(TutorialContext context)
        {
            this.context = context;
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
            this.context = context;
        }

        public Employee Add(Employee employee)
        {
           
            context.Add(employee);
            context.SaveChanges();
            return employee;
        }

        public void Delete(Employee employee)
        {
            context.Remove(employee);
            context.SaveChanges();
        }

        public Employee getEmployee(int id)
        {
            return context.employees.FirstOrDefault(e => e.id == id);   
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return context.employees.ToList();
        }

        public Employee Update(Employee employee)
        {
            var emplo=context.employees.Where(e=>e.id==employee.id).FirstOrDefault();
            employee.id= emplo.id;
            employee.email= emplo.email;
            employee.name= emplo.name;
            employee.Department= emplo.Department;
            context.Update(employee);
            context.SaveChanges();
            return employee;
        }
    }
      
    
}
