using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;


namespace MVCSAMPLE.Models
{
    public class EmailService
    {
        private readonly SMPT _smtpSettings;

        public EmailService(IOptions<SMPT> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {

       
            var mailMessage = new MailMessage
            {
                From = new MailAddress(_smtpSettings.From),
                Subject = "Thank You for Your Shadow Nights Biryani Order!",
                Body = "Dear Customer,<br/>Thank you for choosing Shadow Nights for your biryani craving! We are delighted to confirm that we have received your order and are excited to prepare your delicious biryani.<br/><br/>Our team is working hard to ensure your meal is prepared with the freshest ingredients and delivered promptly. If you have any special requests or need to make changes to your order, please don’t hesitate to contact us at ShadowNightsBiryani@gmail.com <br/><br/>We sincerely appreciate your business and look forward to serving you again soon.<br/><br/><br/>Warm regards,<br/><br/>The Shadow Nights Team",
                IsBodyHtml = true
            };

            mailMessage.To.Add(toEmail);

            using (var smtpClient = new SmtpClient(_smtpSettings.Host, _smtpSettings.Port))
            {
                smtpClient.Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password);
                smtpClient.EnableSsl = _smtpSettings.EnableSsl;

                await smtpClient.SendMailAsync(mailMessage);
            }
        }
    }
}
