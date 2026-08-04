using DgtalVideo.Data;
using DgtalVideo.Data.Models;
using DgtalVideo.Data.Repository.Interfaces;
using DgtalVideo.Hubs;
using DgtalVideo.Hubs.Interfaces;
using DgtalVideo.Models;
using DgtalVideo.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace DgtalVideo.Services
{
    public class AdminPanelService : IAdminPanelService
    {
        private readonly IReviewsRepository _reviewsRepository;
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly IContactFormRepository _contactFormRepository;
        private IHubContext<NoticeHub, INoticeHub> _hubContext;
        public AdminPanelService(IReviewsRepository reviewsRepository, IPortfolioRepository portfolioRepository, IHubContext<NoticeHub, INoticeHub> hubContext, IContactFormRepository contactFormRepository)
        {
            _reviewsRepository = reviewsRepository;
            _portfolioRepository = portfolioRepository;
            _hubContext = hubContext;
            _contactFormRepository = contactFormRepository;
        }
        public AdminPanelViewModel GetAdminPanel()
        {
            var request = _contactFormRepository.GetAllOrdered();
            return new AdminPanelViewModel
            {
                Movies = _portfolioRepository.GetAll().Select(MapMovie).ToList(),
                Reviews = _reviewsRepository.GetAll().Select(MapReview).ToList(),
                ContactRequests = request.Select(MapContactForm).ToList(),
                UnreadRequestCount = request.Count(x => !x.IsRead),
            };
        }
        public void AddMovie(PortfolioViewModel portfolio, int userId)
        {
            var fileMovie = portfolio.FileMovie;
            var urlMovie = string.IsNullOrWhiteSpace(portfolio.UrlMovie) ? fileMovie : portfolio.UrlMovie;
            var portfolioModel = new PortfolioData
            {
                Category = portfolio.Category ?? string.Empty,
                Description = portfolio.Description,
                Title = portfolio.Title ?? string.Empty,
                UrlMovie = urlMovie,
                FileMovie = fileMovie,
                UserCreatedId = userId,
            };
            _portfolioRepository.Add(portfolioModel);
            _hubContext.Clients.All.NewMovieAdded(portfolioModel.Title);
        }

        public void UpdateMovie(PortfolioViewModel portfolio)
        {
            var movieId = _portfolioRepository.GetById(portfolio.Id);
            if (movieId == null)
            {
                return;
            }
            movieId.Title = portfolio.Title ?? string.Empty;
            movieId.Category = portfolio.Category ?? string.Empty;
            movieId.Description = portfolio.Description;
            movieId.UrlMovie = string.IsNullOrWhiteSpace(portfolio.UrlMovie)
                ? movieId.FileMovie
                : portfolio.UrlMovie;
            _portfolioRepository.Update(movieId);
        }
        public void DeleteMovie(int movieId)
        {
            _portfolioRepository.Delete(movieId);
        }

        public void AddReview(ReviewsViewModel reviews, int userId)
        {
            var reviewModel = new ReviewsData
            {
                Name = reviews.Name ?? string.Empty,
                ShortDescription = reviews.ShortDescription ?? string.Empty,
                Text = reviews.Text ?? string.Empty,
                UsersId = userId,
            };
            _reviewsRepository.Add(reviewModel);
        }

        public void DeleteReview(int reviewId)
        {
            _reviewsRepository.Delete(reviewId);
        }
       
        public PortfolioViewModel? GetMovieById(int id)
        {
            var movie = _portfolioRepository.GetById(id);
            return movie == null ? null : MapMovie(movie);
        }
        public void DeleteRequest(int requestId)
        {
            _contactFormRepository.Delete(requestId);
        }
        public void MarkContactRequestAsRead(int id)
        {
            _contactFormRepository.MarkAsRead(id);
        }

        private static ReviewsViewModel MapReview(ReviewsData reviews)
        {
            return new ReviewsViewModel
            {
                Id = reviews.Id,
                Name = reviews.Name ?? string.Empty,
                ShortDescription = reviews.ShortDescription ?? string.Empty,
                Text = reviews.Text ?? string.Empty,
            };
        }

        private static PortfolioViewModel MapMovie(PortfolioData portfolio)
        {
            return new PortfolioViewModel
            {
                Id = portfolio.Id,
                Category = portfolio.Category ?? string.Empty,
                Description = portfolio.Description,
                Title = portfolio.Title ?? string.Empty,
                UrlMovie = portfolio.UrlMovie ?? portfolio.FileMovie,
                FileMovie = portfolio.FileMovie,
            };
        }
        public static ContactFormViewModel MapContactForm(ContactFormData contactForm)
        {
            return new ContactFormViewModel
            {
                Id = contactForm.Id,
                NameCustomer = contactForm.NameCustomer,
                MobilePhone = contactForm.MobilePhone,
                ApplicationText = contactForm.ApplicationText,
                CreatedAt = contactForm.CreatedAt,
                IsRead = contactForm.IsRead,
            };
        }
       
    }
}