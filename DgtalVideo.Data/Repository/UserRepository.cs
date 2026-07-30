using DgtalVideo.Data.Enums;
using DgtalVideo.Data.Models;
using DgtalVideo.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DgtalVideo.Data.Repository
{
    public class UserRepository : BaseRepository<UserData>, IUserRepository
    {
        public UserRepository(WebContext context) : base(context)
        {
        }

        public UserData? GetByLoginAndPassword(string login, string password)
        {
            var hash = GetHashOfPassword(password);
            return _dbSet.FirstOrDefault(x => x.Login == login && x.Password == hash);
        }

        public bool IsNameUniq(string login)
        {
            return !_dbSet.Any(x => x.Login == login);
        }

        public void Registration(UserData user)
        {
            var hash = GetHashOfPassword(user.Password);
            user.Password = hash;
            _dbSet.Add(user);
            _context.SaveChanges();
        }

        public void UpdateLanguage(int userId, Language language)
        {
            var user = _dbSet.First(x => x.Id == userId);
            user.SelectedLanguage = language;
            _context.SaveChanges();
        }

        private string GetHashOfPassword(string password)
        {
            password = password.Replace("o", "e");
            return password.Substring(0, password.Length - 3);
        }
    }
    
}
