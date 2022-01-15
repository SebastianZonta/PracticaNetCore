using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TutorialASPNETCore.ViewModels
{
    public class LogInViewModel
    {
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Display(Name ="Remember me")]
        public bool rememberMe { get; set; }
        public string ReturnUrl { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }
    }
}
