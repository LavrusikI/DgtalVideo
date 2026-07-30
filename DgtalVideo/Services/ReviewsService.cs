using DgtalVideo.Data.Models;
using DgtalVideo.Data.Repository;
using DgtalVideo.Data.Repository.Interfaces;
using DgtalVideo.Models;
using DgtalVideo.Services.Interfaces;

namespace DgtalVideo.Services
{
    public class ReviewsService : IReviewsService
    {
        private readonly IReviewsRepository _reviewRepository;
        public ReviewsService(IReviewsRepository reviewsRepository)
        {
            _reviewRepository = reviewsRepository;
        }

        public List<ReviewsViewModel> GetReviewsForIndexPage()
        {
            var reviews = _reviewRepository.GetAll();
            return reviews.Select(MapReview).ToList();
        }

        private static ReviewsViewModel MapReview(ReviewsData reviews)
        {
            return new ReviewsViewModel
            {
                Id = reviews.Id,
                Name = reviews.Name,
                ShortDescription = reviews.ShortDescription,
                Text = reviews.Text,
            };
    }
}
}
