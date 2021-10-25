using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutorialASPNETCore.Models;
using TutorialASPNETCore.Repositories;

namespace TutorialASPNETCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
           
        }
        public string Index()
        {
           return _employeeRepository.getEmployee(1).name;
        }
        public IActionResult Details()
        {
            Employee employee = _employeeRepository.getEmployee(1);
            return View(employee);
        }
    }
}
