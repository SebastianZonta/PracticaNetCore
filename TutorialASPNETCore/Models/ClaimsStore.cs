using System.Collections.Generic;
using System.Security.Claims;

namespace TutorialASPNETCore.Models
{
    public static class ClaimsStore
    {
        public static List<Claim> allClaims = new List<Claim>()
        {
            new Claim("Create Role","Create Role"),
            new Claim("Edit Role","Edit Role"),
            new Claim("Delete Role","Delete Role")

        }; 
    }
}
