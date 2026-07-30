using DgtalVideo.Data.Models;
using DgtalVideo.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DgtalVideo.Data.Repository
{
    public class ReviewsRepository : BaseRepository<ReviewsData>, IReviewsRepository
    {
        public ReviewsRepository(WebContext context) : base(context)
        {
        }

        public ReviewsData? GetById(int id)
        {
            return _dbSet.FirstOrDefault(r => r.Id == id);
        }
    }
}
