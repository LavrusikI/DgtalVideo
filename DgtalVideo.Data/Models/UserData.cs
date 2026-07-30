using DgtalVideo.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DgtalVideo.Data.Models
{
    public class UserData : BaseModel
    {
        public string Name { get; set; }
        public string MobilePhone { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set;}
        public virtual List<ReviewsData> Reviews { get; set; }
        public virtual List<PortfolioData> PortfolioMovies { get; set; }
        public Language SelectedLanguage { get; set; }
    }
}
