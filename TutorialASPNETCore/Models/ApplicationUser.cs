using Microsoft.AspNetCore.Identity;

namespace TutorialASPNETCore.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string city { get; set; }
    }
}
