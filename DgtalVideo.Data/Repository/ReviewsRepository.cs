using DgtalVideo.Data.Models;
using DgtalVideo.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DgtalVideo.Data.Repository
{
    public class ReviewsRepository : BaseRepository<ReviewsData>, IReviewsRepository
    {
        public ReviewsRepository(WebContext context) : base(context)
        {
        }

        public override List<ReviewsData> GetAll()
        {
            return QuerySafe().ToList();
        }

        public ReviewsData? GetById(int id)
        {
            return QuerySafe().FirstOrDefault(r => r.Id == id);
        }

        public override void Delete(int id)
        {
            _context.Reviews.Where(r => r.Id == id).ExecuteDelete();
        }

        private IQueryable<ReviewsData> QuerySafe()
        {
            return _context.Reviews
                .AsNoTracking()
                .Select(r => new ReviewsData
                {
                    Id = r.Id,
                    Name = r.Name ?? string.Empty,
                    ShortDescription = r.ShortDescription ?? string.Empty,
                    Text = r.Text ?? string.Empty,
                    UsersId = r.UsersId
                });
        }
    }
}
