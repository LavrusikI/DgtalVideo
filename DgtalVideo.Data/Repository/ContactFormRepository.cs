using DgtalVideo.Data.Models;
using DgtalVideo.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DgtalVideo.Data.Repository
{
    public class ContactFormRepository : BaseRepository<ContactFormData>, IContactFormRepository
    {
        public ContactFormRepository(WebContext context) : base(context)
        {
           
        }
        public List<ContactFormData> GetUnread()
        {
            return QuerySafe()
                .Where(x => !x.IsRead)
                .OrderByDescending(x => x.CreatedAt)
                .ToList();
        }
        public List<ContactFormData> GetAllOrdered()
        {
            return QuerySafe()
                .OrderByDescending(x => x.CreatedAt)
                .ToList();
        }
        public void MarkAsRead(int id)
        {
            _context.ContactForm
                .Where(x => x.Id == id)
                .ExecuteUpdate(s => s.SetProperty(x => x.IsRead, true));
        }

        public override void Delete(int id)
        {
            _context.ContactForm.Where(x => x.Id == id).ExecuteDelete();
        }

        private IQueryable<ContactFormData> QuerySafe()
        {
            return _dbSet
                .AsNoTracking()
                .Select(x => new ContactFormData
                {
                    Id = x.Id,
                    MobilePhone = x.MobilePhone ?? string.Empty,
                    NameCustomer = x.NameCustomer ?? string.Empty,
                    ApplicationText = x.ApplicationText ?? string.Empty,
                    CreatedAt = x.CreatedAt,
                    IsRead = x.IsRead
                });
        }
    }
}
