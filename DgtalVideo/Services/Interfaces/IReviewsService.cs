using DgtalVideo.Models;

namespace DgtalVideo.Services.Interfaces
{
    public interface IReviewsService
    {
        List<ReviewsViewModel> GetReviewsForIndexPage();
    }
}
