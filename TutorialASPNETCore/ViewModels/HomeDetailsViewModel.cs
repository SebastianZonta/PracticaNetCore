using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutorialASPNETCore.Models;

namespace TutorialASPNETCore.ViewModels
{
    public class HomeDetailsViewModel
    {
        public Employee employee { get; set; }
        public string PageTitle { get; set; }
    }
}
