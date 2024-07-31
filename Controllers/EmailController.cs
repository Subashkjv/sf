using Microsoft.AspNetCore.Mvc;
using MVCSAMPLE.Models;


namespace MVCSAMPLE.Controllers
{
    public class EmailController : Controller
    {
        private readonly EmailService _emailService;

        public EmailController(EmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet]
        public IActionResult ContactInfo()
        {
            return View(new ContactViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> SubmitContact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                string subject = "Contact Us Form Submission";
                string body = $"Name: {model.Name}<br>Email: {model.Email}<br>Message: {model.Message}";

                await _emailService.SendEmailAsync("recipient@example.com", subject, body);

                ViewBag.Message = "Thank you for contacting us!";
                return View("ContactInfo", new ContactViewModel());
            }

            return View("ContactInfo", model);
        }
    }
}
