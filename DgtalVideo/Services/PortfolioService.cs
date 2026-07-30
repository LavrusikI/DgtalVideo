using DgtalVideo.Data.Models;
using DgtalVideo.Data.Repository;
using DgtalVideo.Data.Repository.Interfaces;
using DgtalVideo.Models;
using DgtalVideo.Services.Interfaces;

namespace DgtalVideo.Services
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IPortfolioRepository _portfolioRepository;

        public PortfolioService(IPortfolioRepository portfolioRepository)
        {
            _portfolioRepository = portfolioRepository;
        }
        public List<PortfolioViewModel> GetMoviesForPortfolioPage()
        {
            var movies = _portfolioRepository.GetAll();
            return movies.Select(MapMovie).ToList();
        }
        private PortfolioViewModel MapMovie(PortfolioData portfolio)
        {
            return new PortfolioViewModel
            {
                Id = portfolio.Id,
                Title = portfolio.Title,
                Category = portfolio.Category,
                Description = portfolio.Description,
                UrlMovie = portfolio.UrlMovie,
            };
        }
    }
}
