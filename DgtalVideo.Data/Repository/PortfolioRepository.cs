using DgtalVideo.Data.Models;
using DgtalVideo.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DgtalVideo.Data.Repository
{
    public class PortfolioRepository : BaseRepository<PortfolioData>, IPortfolioRepository
    {
        public PortfolioRepository(WebContext webContext) : base(webContext)
        {
        }

        public override List<PortfolioData> GetAll()
        {
            return QuerySafe().ToList();
        }

        public PortfolioData? GetById(int id)
        {
            return QuerySafe().FirstOrDefault(p => p.Id == id);
        }

        public override void Delete(int id)
        {
            _context.Portfolio.Where(p => p.Id == id).ExecuteDelete();
        }

        private IQueryable<PortfolioData> QuerySafe()
        {
            return _context.Portfolio
                .AsNoTracking()
                .Select(p => new PortfolioData
                {
                    Id = p.Id,
                    Title = p.Title ?? string.Empty,
                    Category = p.Category ?? string.Empty,
                    Description = p.Description,
                    UrlMovie = p.UrlMovie ?? p.FileMovie,
                    FileMovie = p.FileMovie,
                    UserCreatedId = p.UserCreatedId
                });
        }
    }
}
