using DgtalVideo.Data.Enums;
using DgtalVideo.Data.Models;

namespace DgtalVideo.Services.Interfaces
{
    public interface IAuthService
    {
        Language GetLanguage();
        bool isAdmin(UserData user);
    }
}
