using DgtalVideo.Data.Enums;
using DgtalVideo.Data.Models;
using DgtalVideo.Data.Repository.Interfaces;
using DgtalVideo.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DgtalVideo.Services
{
    public class AuthService : IAuthService
    {
        public const string AUTH_KEY = "AuthCookie";
        public const string COOKIE_LANGUAGE_KEY = "Language";
        private IHttpContextAccessor _httpContextAccessor;

        public AuthService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool isAdmin(UserData user)
        {
            return user.Role == UserRole.Admin;
        }
        public bool IsAutenticated()
        {
            return _httpContextAccessor?.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
        }

        public Language GetLanguage()
        {
            if (!IsAutenticated())
            {
                return Language.Russsian;
            }
            var languageClaim = _httpContextAccessor.HttpContext?
              .User?
              .Claims
              .FirstOrDefault(x => x.Type == COOKIE_LANGUAGE_KEY);
            if (languageClaim == null ||
                !Enum.TryParse<Language>(languageClaim.Value, out var language))
            {
                return Language.Russsian;
            }
            return language;
        }
    }
}