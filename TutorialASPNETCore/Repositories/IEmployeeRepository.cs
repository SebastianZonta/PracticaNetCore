using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TutorialASPNETCore.Models
{
    public interface IEmployeeRepository
    {
        Employee getEmployee(int id);
        IEnumerable<Employee> GetEmployees();
        Employee Add(Employee employee); 
        Employee Update(Employee employee);
        void Delete(Employee employee);

    }
}
