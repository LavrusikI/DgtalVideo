using System.ComponentModel.DataAnnotations;

namespace DgtalVideo.Models.CustomValidationAttribute
{
    public class CheckLengthTextAttribute : ValidationAttribute
    {
        public int minLength { get; }
        public int maxLength { get; }
        public override string FormatErrorMessage(string name)
        {
            return $"The length must be between {minLength} and {maxLength} characters.";
        }
        public CheckLengthTextAttribute(int min, int max)
        {
            minLength = min;
            maxLength = max;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }
            if (value is not string str)
            {
                return new ValidationResult(ErrorMessage ?? "Invalid value");
            }
            if (str.Length >= minLength && str.Length <= maxLength)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult(ErrorMessage ?? FormatErrorMessage(validationContext.DisplayName));
        }
    }
}
