using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly IWebHostEnvironment _hosting;
        private readonly ILogger<HomeController> logger;

        public HomeController(IEmployeeRepository employeeRepository,
                                IWebHostEnvironment hostingEnvironment,
                                ILogger<HomeController> logger)
        {
            _employeeRepository = employeeRepository;
            _hosting = hostingEnvironment;
            this.logger = logger;
        }


        public IActionResult Index()
        {
            logger.LogInformation("aaaaaaa information");
            logger.LogWarning("bbbb warning");
            return View(_employeeRepository.GetEmployees());

        }

        public IActionResult Details(int? id)
        {
            //throw new Exception("no pasas");
            var employee = _employeeRepository.getEmployee(id.Value);
            if (employee is null)
            {
                Response.StatusCode = 404;
 
                
                return View("EmployeeNotFound",id.Value);
            }
            HomeDetailsViewModel homeDetailsView = new()
            {
                employee = _employeeRepository.getEmployee(id ?? 1),
                PageTitle = "Employee details"
            };
            return View(homeDetailsView);

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {

            Employee employee = _employeeRepository.getEmployee(id);
            EmployeeEditViewModel employeeEditViewModel = new()
            {
                id = employee.id,
                email = employee.email,
                Department = employee.Department,
                name = employee.name,
                existingPhoto = employee.photoPath
            };
            return View(employeeEditViewModel);
        }
        public async Task<IActionResult> Edit(EmployeeEditViewModel employee)
        {
            if (ModelState.IsValid)
            {
                Employee employee1 = _employeeRepository.getEmployee(employee.id);
                _employeeRepository.Delete(employee1);
                employee1.name = employee.name;
                employee1.Department = employee.Department;
                employee1.email = employee.email;
                string fileName = processUserPhoto(employee);
                if (employee.photoPath != null)
                {
                    if (employee.existingPhoto != null)
                    {
                        string filePath=Path.Combine(_hosting.WebRootPath, "images", employee.existingPhoto);
                        System.IO.File.Delete(filePath);
                    }
                    employee1.photoPath = this.processUserPhoto(employee);
                }
                Employee emplo = new Employee()
                {
                    name = employee.name,
                    photoPath = fileName,
                    Department = employee.Department,
                    email = employee.email
                };
                _employeeRepository.Add(emplo);
                return RedirectToAction("index");

            }
            return View();
        }

        private string processUserPhoto(CreateEmployeeViewModel employee)
        {
            string fileName = null;
            if (employee.photoPath is not null)
            {


                string uploadFolder = Path.Combine(_hosting.WebRootPath, "images");
                fileName = Guid.NewGuid().ToString() + "_" + employee.photoPath.FileName;
                String filePath = Path.Combine(uploadFolder, fileName);
                employee.photoPath.CopyTo(new FileStream(filePath, FileMode.Create));

            }

            return fileName;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                string fileName = null;
                if (employee.photoPath is not null)
                {


                    string uploadFolder = Path.Combine(_hosting.WebRootPath, "images");
                    fileName = Guid.NewGuid().ToString() + "_" + employee.photoPath.FileName;
                    String filePath = Path.Combine(uploadFolder, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        employee.photoPath.CopyTo(stream);

                    }

                }
                Employee emplo = new Employee()
                {
                    name = employee.name,
                    photoPath = fileName,
                    Department = employee.Department,
                    email = employee.email
                };
                _employeeRepository.Add(emplo);
                return RedirectToAction("details", new { id = emplo.id });

            }
            return View();
        }
    }
}
