namespace DgtalVideo.Models
{
    public class ContactFormViewModel
    {
        public int Id { get; set; }
        public string MobilePhone { get; set; }
        public string NameCustomer { get; set; }
        public string ApplicationText { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}