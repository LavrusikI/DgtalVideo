using DgtalVideo.Models;

namespace DgtalVideo.Services.Interfaces
{
    public interface IPortfolioService
    {
        List<PortfolioViewModel> GetMoviesForPortfolioPage();
    }
}
