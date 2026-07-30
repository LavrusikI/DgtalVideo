using DgtalVideo.Data.Models;
using DgtalVideo.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DgtalVideo.Data.Repository
{
    public class ContactFormRepository : BaseRepository<ContactFormData>, IContactFormRepository
    {
        public ContactFormRepository(WebContext context) : base(context)
        {
           
        }
        public List<ContactFormData> GetUnread()
        {
            return _dbSet
                .Where(x => !x.IsRead)
                .OrderByDescending(x => x.CreatedAt)
                .ToList();
        }
        public List<ContactFormData> GetAllOrdered()
        {
            return _dbSet
                .OrderByDescending(x => x.CreatedAt)
                .ToList();
        }
        public void MarkAsRead(int id)
        {
            var item = _dbSet.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return;
            }
            item.IsRead = true;
            _context.SaveChanges();
        }
    }
}
