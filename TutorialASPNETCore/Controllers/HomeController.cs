using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutorialASPNETCore.Models;
using TutorialASPNETCore.Repositories;
using TutorialASPNETCore.ViewModels;

namespace TutorialASPNETCore.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
           
        }
        
        
        public IActionResult Index()
        {
             return View(_employeeRepository.GetEmployees());
           
        }
        
        public IActionResult Details(int? id)
        {
            HomeDetailsViewModel homeDetailsView = new()
            {
                employee = _employeeRepository.getEmployee(id??1),
                PageTitle = "Employee details"
            };
            return View(homeDetailsView);
            
        }
    }
}
