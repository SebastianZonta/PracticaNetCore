using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TutorialASPNETCore.Utilities;

namespace TutorialASPNETCore.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Remote(action: "isEmailInUse", "Account")]
        [ValidEmailDomain(allowedDomain:"puta.com",ErrorMessage ="No cumple con puta.com")]
        public string email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Display(Name ="Confirmar contra")]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage ="They don't match puto de mierda")]
        public string confirmPassword { get; set; }
        [Required]
        [MaxLength(30)]
        public string city { get; set; }
    }
}
