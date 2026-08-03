using DgtalVideo.Models.CustomValidationAttribute;

namespace DgtalVideo.Models
{
    public class PortfolioViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [CheckLengthTextAttribute(3,20)]
        public string Category { get; set; }
        [CheckLengthTextAttribute(5,150)]
        public string? Description { get; set; }
        public string? UrlMovie { get; set; }
        public string? FileMovie { get; set; }
    }
}
