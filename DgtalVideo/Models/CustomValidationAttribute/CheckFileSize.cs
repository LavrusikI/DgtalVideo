using System.ComponentModel.DataAnnotations;

namespace DgtalVideo.Models.CustomValidationAttribute
{
    public class CheckFileSize : ValidationAttribute
    {
        private readonly long _maxFileSize;

        public CheckFileSize(long maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                if (file.Length > _maxFileSize)
                {
                    return new ValidationResult("Размер файла превышает допустимый.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
