using DgtalVideo.Data.Enums;
using DgtalVideo.Data.Models;
using DgtalVideo.Data.Repository.Interfaces;
using DgtalVideo.Models;
using DgtalVideo.Services;
using DgtalVideo.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace DgtalVideo.Controllers
{
    public class AuthController : Controller
    {
        private IUserRepository _userRepository;
        private IAuthService _authService;

        public AuthController(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var user = _userRepository.GetByLoginAndPassword(viewModel.Login, viewModel.Password);
            if (user == null)
            {
                ModelState.AddModelError(viewModel.Login, "Неправильно введен логин или пароль");
                return View(viewModel);
            }

            var claims = new List<Claim>
            {
                new Claim("Id", user.Id.ToString()),
                new Claim("Role", user.Role.ToString()),
                new Claim(AuthService.COOKIE_LANGUAGE_KEY, user.SelectedLanguage.ToString()),
                new Claim(ClaimTypes.AuthenticationMethod, AuthService.AUTH_KEY)
            };

            var identity = new ClaimsIdentity(claims, AuthService.AUTH_KEY);
            var principal = new ClaimsPrincipal(identity);

            HttpContext
                .SignInAsync(AuthService.AUTH_KEY, principal)
                .Wait();

            if (user.Role == UserRole.Admin)
            {
                return RedirectToAction("AdminPanel", "AdminPanel");
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Deny()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(AuthService.AUTH_KEY);
            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult Registration()
        {
            var viewModel = new UserViewModel
            {
                SelectedLanguage = _authService.GetLanguage(),
                ListLanguages = GetLanguagesList()
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Registration(UserViewModel viewModel)
        {
            viewModel.ListLanguages = GetLanguagesList();
            if (!_userRepository.IsNameUniq(viewModel.Login))
            {
                ModelState.AddModelError(nameof(viewModel.Login), "Пользователь с таким именем уже зарегистрирован");
                return View(viewModel);
            }
            var user = new UserData
            {
                Name = viewModel.Name,
                MobilePhone = viewModel.MobilePhone,
                Role = UserRole.Guest,
                Login = viewModel.Login,
                Password = viewModel.Password,
                SelectedLanguage = viewModel.SelectedLanguage,
            };
            _userRepository.Registration(user);
            return RedirectToAction("Login", "Auth");
        }

        private List<SelectListItem> GetLanguagesList()
        {
            var currentUserLanguage = _authService.GetLanguage();
            return Enum
                .GetNames<Language>()
                .Select(x => new SelectListItem
                {
                    Text = x,
                    Value = x,
                    Selected = x == currentUserLanguage.ToString()
                })
                .ToList();
        }
    }
}