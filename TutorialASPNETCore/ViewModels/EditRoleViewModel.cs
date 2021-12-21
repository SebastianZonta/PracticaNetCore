using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TutorialASPNETCore.ViewModels
{
    public class EditRoleViewModel
    {
        public EditRoleViewModel()
        {
            users = new List<string>();
        }
        public string id { get; set; }
        [Required]
        public string nameRole { get; set; }
        public List<string> users { get; set; }
    }
}
