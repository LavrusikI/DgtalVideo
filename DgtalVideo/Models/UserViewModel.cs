using DgtalVideo.Data.Enums;
using DgtalVideo.Models.CustomValidationAttribute;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace DgtalVideo.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [CheckCorrectPhoneNumberAttribute]
        public string MobilePhone { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Language SelectedLanguage { get; set; }
        public List<SelectListItem> ListLanguages { get; set; } = new();
    }
}
