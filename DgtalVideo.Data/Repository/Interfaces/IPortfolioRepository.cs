using DgtalVideo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DgtalVideo.Data.Repository.Interfaces
{
    public interface IPortfolioRepository : IBaseRepository<PortfolioData>
    {
        PortfolioData? GetById(int id);
    }
}
