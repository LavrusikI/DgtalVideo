using DgtalVideo.Data.Models;
using DgtalVideo.Models;

namespace DgtalVideo.Services.Interfaces
{
    public interface IAdminPanelService
    {
        void AddMovie(PortfolioViewModel portfolio, int userId);
        void AddReview(ReviewsViewModel reviews, int userId);
        void DeleteMovie(int movieId);
        void DeleteRequest(int requestId);
        void DeleteReview(int reviewId);
        AdminPanelViewModel GetAdminPanel();
        PortfolioViewModel? GetMovieById(int id);
        void MarkContactRequestAsRead(int id);
        void UpdateMovie(PortfolioViewModel portfolio);
    }
}
