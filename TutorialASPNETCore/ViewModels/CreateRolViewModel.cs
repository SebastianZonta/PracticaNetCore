using System.ComponentModel.DataAnnotations;

namespace TutorialASPNETCore.ViewModels
{
    public class CreateRolViewModel
    {
        [Required]
        public string rolName { get; set; }
    }
}
