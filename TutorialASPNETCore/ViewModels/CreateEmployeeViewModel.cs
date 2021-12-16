using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TutorialASPNETCore.Models;

namespace TutorialASPNETCore.ViewModels
{
    public class CreateEmployeeViewModel
    {
        [Required]
        public string name { get; set; }
        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Formato de mail incorrecto")]
        public string email { get; set; }
        [Required]
        public Department? Department { get; set; }
        public IFormFile photoPath { get; set; }

    }
}
