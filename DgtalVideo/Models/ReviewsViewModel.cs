using DgtalVideo.Models.CustomValidationAttribute;

namespace DgtalVideo.Models
{
    public class ReviewsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [CheckLengthTextAttribute(3, 20)]
        public string ShortDescription { get; set; }
        [CheckLengthTextAttribute(10,100)]
        public string Text { get; set; }
    }
}
