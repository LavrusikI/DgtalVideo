using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DgtalVideo.Models.CustomValidationAttribute
{
    public class CheckCorrectPhoneNumberAttribute : ValidationAttribute
    {
        private static readonly Regex phoneRegex = new(@"^(?:\+7|8)?9\d{9}$");
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string phoneStr && phoneRegex.IsMatch(phoneStr))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult(ErrorMessage ?? "Invalid data format");
        }
    }
}
