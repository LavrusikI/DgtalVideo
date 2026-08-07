using DgtalVideo.Data.Enums;
using DgtalVideo.Data.Models;
using DgtalVideo.Data.Repository.Interfaces;
using DgtalVideo.Hubs;
using DgtalVideo.Hubs.Interfaces;
using DgtalVideo.Localizations.Enums;
using DgtalVideo.Models;
using DgtalVideo.Models.CustomValidationAttribute;
using DgtalVideo.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DgtalVideo.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminPanelController : Controller
    {
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly IPortfolioService _portfolioService;
        private readonly IAdminPanelService _adminPanelService;
        private readonly IWebHostEnvironment _environment;

        public AdminPanelController(
            IAdminPanelService adminPanelService,
            IPortfolioRepository portfolioRepository,
            IPortfolioService portfolioService,
            IWebHostEnvironment environment)
        {
            _adminPanelService = adminPanelService;
            _portfolioRepository = portfolioRepository;
            _portfolioService = portfolioService;
            _environment = environment;
        }
        [HttpGet]
        public IActionResult AdminPanel(int? editId)
        {
            var adminPanelModel = _adminPanelService.GetAdminPanel();
            if (editId.HasValue)
            {
                adminPanelModel.EditingPortfolio = _adminPanelService.GetMovieById(editId.Value);
                if (adminPanelModel.EditingPortfolio == null)
                {
                    return RedirectToAction(nameof(AdminPanel));
                }
            }
            return View(adminPanelModel);
        }

        [HttpPost]
        public IActionResult AddMovieFromPortfolio([Bind(Prefix = "NewPortfolio")] PortfolioViewModel portfolio, [CheckFileSize (35*1024*1024)] IFormFile? movie)
        {
            if (!ModelState.IsValid)
            {
                var panel = _adminPanelService.GetAdminPanel();
                panel.NewPortfolio = portfolio;
                ViewBag.ShowPortfolioForm = true;
                return View("AdminPanel", panel);
            }

            if (movie != null && movie.Length > 0)
            {
                var allowedExtensions = new[] { ".mp4", ".mov" };
                var extension = Path.GetExtension(movie.FileName);
                var movieName = $"{Guid.NewGuid():N}{extension.ToLowerInvariant()}";

                if (string.IsNullOrEmpty(extension) || !allowedExtensions.Contains(extension))
                {
                    return BadRequest("Недопустимое расширение файла.");
                }
               
                var pathToFolder = Path.Combine(_environment.WebRootPath, "videos");
                Directory.CreateDirectory(pathToFolder);
                var path = Path.Combine(pathToFolder, movieName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    movie.CopyTo(fileStream);
                }
           
                var relativeUrl = $"/videos/{movieName}";
                portfolio.FileMovie = relativeUrl;
                if (string.IsNullOrWhiteSpace(portfolio.UrlMovie))
                {
                    portfolio.UrlMovie = relativeUrl;
                }
            }

            var userId = GetCurrentUserId();
            _adminPanelService.AddMovie(portfolio, userId);
            return RedirectToAction(nameof(AdminPanel));
        }

        [HttpPost]
        public IActionResult UpdateMovie([Bind(Prefix = "EditingPortfolio")] PortfolioViewModel portfolio)
        {
            if (!ModelState.IsValid)
            {
                var panel = _adminPanelService.GetAdminPanel();
                panel.EditingPortfolio = portfolio;
                return View("AdminPanel", panel);
            }
            _adminPanelService.UpdateMovie(portfolio);
            return RedirectToAction(nameof(AdminPanel));
        }

        [HttpPost]
        public IActionResult DeleteMovie(int id)
        {
            _adminPanelService.DeleteMovie(id);
            return RedirectToAction(nameof(AdminPanel));
        }
        [HttpPost]
        public IActionResult AddReviewFromReviews([Bind(Prefix = "NewReview")] ReviewsViewModel reviews)
        {
            if (!ModelState.IsValid)
            {
                var panel = _adminPanelService.GetAdminPanel();
                panel.NewReview = reviews;
                ViewBag.ShowReviewForm = true;
                return View("AdminPanel", panel);
            }
            var userId = GetCurrentUserId();
            _adminPanelService.AddReview(reviews, userId);
            return RedirectToAction(nameof(AdminPanel));
        }
        [HttpPost]
        public IActionResult DeleteReview(int id)
        {
            _adminPanelService.DeleteReview(id);
            return RedirectToAction(nameof(AdminPanel));
        }
        private int GetCurrentUserId()
        {
            return int.Parse(User.FindFirst("Id")!.Value);
        }
        public IActionResult MarkContactRequestAsRead(int id)
        {
            _adminPanelService.MarkContactRequestAsRead(id);
            return RedirectToAction(nameof(AdminPanel));
        }
        [HttpPost]
        public IActionResult DeleteRequest(int id)
        {
            _adminPanelService.DeleteRequest(id);
            return RedirectToAction(nameof(AdminPanel));
        }
    }
}