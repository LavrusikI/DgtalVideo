using DgtalVideo.Models.CustomValidationAttribute;
using System.ComponentModel.DataAnnotations;

namespace DgtalVideo.Models
{
    public class ContactFormViewModel
    {
        public int Id { get; set; }
        [CheckCorrectPhoneNumberAttribute]
        public string MobilePhone { get; set; }
        public string NameCustomer { get; set; }
        [CheckLengthTextAttribute(5,150)]
        public string ApplicationText { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}