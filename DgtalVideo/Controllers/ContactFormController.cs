using DgtalVideo.Models;
using DgtalVideo.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DgtalVideo.Controllers
{
    public class ContactFormController : Controller
    {
        private readonly IContactFormService _contactFormService;

        public ContactFormController(IContactFormService contactFormService)
        {
            _contactFormService = contactFormService;
        }
        public IActionResult ContactForm()
        {
            return View();
        }
        public async Task<IActionResult> SubmitContactForm(ContactFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("ContactForm", viewModel);
            }
            _contactFormService.MapContactForm(viewModel);
            TempData["Success"] = "Заявка отправлена";
            return RedirectToAction(nameof(ContactForm));
        }
    }

}
