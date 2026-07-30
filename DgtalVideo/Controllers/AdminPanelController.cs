using DgtalVideo.Data.Models;
using DgtalVideo.Data.Repository.Interfaces;
using DgtalVideo.Hubs;
using DgtalVideo.Hubs.Interfaces;
using DgtalVideo.Models;
using DgtalVideo.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DgtalVideo.Controllers
{
    [Authorize]
    public class AdminPanelController : Controller
    {
        private readonly IAdminPanelService _adminPanelService;
        public AdminPanelController(IAdminPanelService adminPanelService)
        {
            _adminPanelService = adminPanelService;
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
        public IActionResult AddMovieFromPortfolio([Bind(Prefix = "NewPortfolio")] PortfolioViewModel portfolio)
        {
            if (!ModelState.IsValid)
            {
                var panel = _adminPanelService.GetAdminPanel();
                panel.NewPortfolio = portfolio;
                ViewBag.ShowPortfolioForm = true;
                return View("AdminPanel", panel);
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
    }
}