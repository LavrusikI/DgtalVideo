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
            var portfolioModel = new PortfolioData
            {
                Category = portfolio.Category,
                Description = portfolio.Description,
                Title = portfolio.Title,
                UrlMovie = portfolio.UrlMovie,
                FileMovie = portfolio.FileMovie,
                UserCreatedId = userId,
            };
            _portfolioRepository.Add(portfolioModel);
            _hubContext.Clients.All.NewMovieAdded(portfolio.Title);
        }

        public void UpdateMovie(PortfolioViewModel portfolio)
        {
            var movieId = _portfolioRepository.GetById(portfolio.Id);
            if (movieId == null)
            {
                return;
            }
            movieId.Title = portfolio.Title;
            movieId.Category = portfolio.Category;
            movieId.Description = portfolio.Description;
            movieId.UrlMovie = portfolio.UrlMovie;
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
                Name = reviews.Name,
                ShortDescription = reviews.ShortDescription,
                Text = reviews.Text,
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
                Name = reviews.Name,
                ShortDescription = reviews.ShortDescription,
                Text = reviews.Text,
            };
        }

        private static PortfolioViewModel MapMovie(PortfolioData portfolio)
        {
            return new PortfolioViewModel
            {
                Id = portfolio.Id,
                Category = portfolio.Category,
                Description = portfolio.Description,
                Title = portfolio.Title,
                UrlMovie = portfolio.UrlMovie,
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