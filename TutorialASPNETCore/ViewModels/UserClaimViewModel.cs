using System.Collections.Generic;

namespace TutorialASPNETCore.ViewModels
{
    public class UserClaimViewModel
    {
        public UserClaimViewModel()
        {
            userClaims = new List<UserClaim>();
        }
        public string userId { get; set; }
        public List<UserClaim> userClaims { get; set; }
    }
}
