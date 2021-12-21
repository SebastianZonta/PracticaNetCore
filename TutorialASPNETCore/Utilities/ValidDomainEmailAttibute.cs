using System.ComponentModel.DataAnnotations;

namespace TutorialASPNETCore.Utilities
{
    public class ValidDomainEmailAttibute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return base.IsValid(value);
        }
    }
}
