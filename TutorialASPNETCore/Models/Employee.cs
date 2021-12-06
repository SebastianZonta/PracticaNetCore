using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TutorialASPNETCore.Models
{
    public class Employee
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$",ErrorMessage ="Formato de mail incorrecto")]
        public string email { get; set; }
        [Required]
        public Department? Department { get; set; }
        public string photoPath { get; set; }
    }
}
