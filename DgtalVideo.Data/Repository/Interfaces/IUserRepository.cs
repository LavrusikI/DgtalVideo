using DgtalVideo.Data.Enums;
using DgtalVideo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DgtalVideo.Data.Repository.Interfaces
{
    public interface IUserRepository : IBaseRepository<UserData>
    {
        UserData? GetByLoginAndPassword(string login, string password);
        bool IsNameUniq(string login);
        void Registration(UserData user);
        void UpdateLanguage(int userId, Language language);
    }
}
