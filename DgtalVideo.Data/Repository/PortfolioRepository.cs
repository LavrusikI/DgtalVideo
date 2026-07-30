using DgtalVideo.Data.Models;
using DgtalVideo.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DgtalVideo.Data.Repository
{
    public class PortfolioRepository : BaseRepository<PortfolioData>, IPortfolioRepository
    {
        public PortfolioRepository(WebContext webContext) : base(webContext)
        {

        }
        public PortfolioData? GetById(int id)
        {
            return _context.Portfolio
                .FirstOrDefault(p => p.Id == id)!;
        }
    }
}
