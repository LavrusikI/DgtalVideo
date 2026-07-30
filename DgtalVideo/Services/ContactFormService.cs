using DgtalVideo.Data.Models;
using DgtalVideo.Data.Repository.Interfaces;
using DgtalVideo.Hubs;
using DgtalVideo.Hubs.Interfaces;
using DgtalVideo.Models;
using DgtalVideo.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.SignalR;

namespace DgtalVideo.Services
{
    public class ContactFormService : IContactFormService
    {
        private readonly IContactFormRepository _contactFormRepository;
        private IHubContext<NoticeHub, INoticeHub> _hubContext;
        public ContactFormService(IContactFormRepository contactFormRepository, IHubContext<NoticeHub, INoticeHub> hubContext)
        {
            _contactFormRepository = contactFormRepository;
            _hubContext = hubContext;
        }

        public void MapContactForm(ContactFormViewModel viewModel)
        {
            var contactForm = new ContactFormData
            {
                NameCustomer = viewModel.NameCustomer,
                MobilePhone = viewModel.MobilePhone,
                ApplicationText = viewModel.ApplicationText,
                CreatedAt = viewModel.CreatedAt,
                IsRead = false,
            };
            _contactFormRepository.Add(contactForm);
            _hubContext.Clients.All.NewContactRequest(viewModel.NameCustomer, viewModel.MobilePhone);
        }

    }
}
