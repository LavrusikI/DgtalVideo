using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DgtalVideo.Data.Models
{
    public class PortfolioData : BaseModel
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public string? Description { get; set; }
        public string? UrlMovie { get; set; }
        public int UserCreatedId { get; set; }
        public virtual UserData UserCreated { get; set; }
        public string? FileMovie { get; set; }
    }
}
