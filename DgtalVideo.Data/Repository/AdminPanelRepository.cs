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
    public class AdminPanelRepository : BaseRepository<UserData>, IAdminPanelRepository
    {
        public AdminPanelRepository(WebContext context) : base(context)
        { 
         
        }
        public UserData? GetByLogin(string login)
        {
            return _dbSet.FirstOrDefault(u => u.Login == login)!;
        }
    }
}
