using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DgtalVideo.Data.Models
{
    public class ReviewsData : BaseModel
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Text { get; set; }
        public int UsersId { get; set; }
        public virtual UserData Users { get; set; }
    }
}
