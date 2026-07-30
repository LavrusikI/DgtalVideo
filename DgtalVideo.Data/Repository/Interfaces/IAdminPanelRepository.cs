using DgtalVideo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DgtalVideo.Data.Repository.Interfaces
{
    public interface IAdminPanelRepository : IBaseRepository<UserData>
    {
        UserData? GetByLogin(string login);
    }
}
