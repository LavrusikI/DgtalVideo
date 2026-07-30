using DgtalVideo.Data.Repository.Interfaces;
using DgtalVideo.Models;
using DgtalVideo.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;

namespace DgtalVideo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPortfolioService _portfolioService;
        private readonly IReviewsService _reviewsService;
        private readonly IAuthService _authService;

        public HomeController(IPortfolioService portfolioService, IReviewsService reviewsService, IAuthService authService)
        {
            _portfolioService = portfolioService;
            _reviewsService = reviewsService;
            _authService = authService;
        }

        public IActionResult Index()
        {
            var culture = _authService.GetLanguage() switch
            {
                Data.Enums.Language.Russsian => new CultureInfo("ru-RU"),
                Data.Enums.Language.English => new CultureInfo("en-US"),
                _ => throw new NotImplementedException()
            };

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            var viewModel = new IndexViewModel
            {
                Reviews = _reviewsService.GetReviewsForIndexPage()
            };
            return View(viewModel);
        }

        public IActionResult Services()
        {
            return View();
        }
        public IActionResult Portfolio()
        {
            var movies = _portfolioService.GetMoviesForPortfolioPage();
            return View(movies);
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(string name, string phone, string email, string message)
        {
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}