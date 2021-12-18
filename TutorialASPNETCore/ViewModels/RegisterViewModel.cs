using System.ComponentModel.DataAnnotations;

namespace TutorialASPNETCore.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Display(Name ="Confirmar contra")]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage ="They don't match puto de mierda")]
        public string confirmPassword { get; set; }
    }
}
