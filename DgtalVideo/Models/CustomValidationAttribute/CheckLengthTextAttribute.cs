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
            if (value is string str)
            {
                if (str.Length >= minLength && str.Length <= maxLength)
                {
                    return ValidationResult.Success;
                }
                else if (value == null)
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult(ErrorMessage);
            }
            return base.IsValid(value, validationContext);
        }
    }
}
