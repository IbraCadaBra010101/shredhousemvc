using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using shredhousepage.Models;

using System.Threading.Tasks;

namespace shredhousepage.Services
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;

        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        public MailSettings Options { get; set; } 
        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.From.Add(new MailboxAddress(mailRequest.Body, _mailSettings.Mail));
            email.To.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Mail));
            var builder = new BodyBuilder();
      
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, 25, false);
            smtp.Send(email);
            smtp.Disconnect(true);

        }
    }
}
