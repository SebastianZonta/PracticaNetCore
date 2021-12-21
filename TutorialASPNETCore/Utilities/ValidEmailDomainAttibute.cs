using System.ComponentModel.DataAnnotations;

namespace TutorialASPNETCore.Utilities
{
    public class ValidEmailDomain: ValidationAttribute
    {
        private readonly string allowedDomain;

        public ValidEmailDomain(string allowedDomain)
        {
            this.allowedDomain = allowedDomain;
        }
        public override bool IsValid(object value)
        {
            string[] emails=value.ToString().Split('@');
            return emails[1].ToUpper()==allowedDomain.ToUpper();
        }
    }
}
