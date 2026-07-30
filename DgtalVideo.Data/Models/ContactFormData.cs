using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DgtalVideo.Data.Models
{
    public class ContactFormData : BaseModel
    {
        public string MobilePhone { get; set; }
        public string NameCustomer { get; set; }
        public string ApplicationText { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsRead { get; set; } = false;
    }
}
