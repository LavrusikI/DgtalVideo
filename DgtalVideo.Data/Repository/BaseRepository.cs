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
    public abstract class BaseRepository<DataModel> : IBaseRepository<DataModel> where DataModel : BaseModel
    {
        protected WebContext _context;
        protected DbSet<DataModel> _dbSet;

        protected BaseRepository(WebContext context)
        {
            _context = context;
            _dbSet = _context.Set<DataModel>();
        }

        public virtual void Add(DataModel model)
        {
            _dbSet.Add(model);
            _context.SaveChanges();
        }

        public virtual void Remove(DataModel model)
        {
            _dbSet.Remove(model);
            _context.SaveChanges();
        }

        public virtual DataModel? Get(int id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public virtual List<DataModel> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual void Delete(int id)
        {
            var movie = _dbSet.FirstOrDefault(m => m.Id == id);
            if (movie != null) 
            {
                _dbSet.Remove(movie);
                _context.SaveChanges();
            }
        }

        public void Update(DataModel model) 
        {
            _dbSet.Update(model);
            _context.SaveChanges();
        }
    }

}
