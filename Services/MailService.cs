using FluentEmail.Core;
using FluentEmail.Razor;
using FluentEmail.Smtp;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using shredhousepage.Models;
using MimeKit;
using Microsoft.Extensions.Options;

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
           
            //email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            //email.From.Add(new MailboxAddress(mailRequest.Body, _mailSettings.Mail));
            //email.To.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Mail));
            //var builder = new BodyBuilder();
      
            //builder.HtmlBody = mailRequest.Body;
            //email.Body = builder.ToMessageBody();

            // send to local folder
            var sender = new SmtpSender(() => new SmtpClient(_mailSettings.Host)
            {
                EnableSsl = false,
                //DeliveryMethod = SmtpDeliveryMethod.Network,
                Port = 25,
                DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
                PickupDirectoryLocation = _mailSettings.LocalFolder
            });

            Email.DefaultSender = sender;
            Email.DefaultRenderer = new RazorRenderer();

            var email = await Email
               .From(mailRequest.FromEmail)
               .To(_mailSettings.Mail, _mailSettings.DisplayName)
               .Subject("Contactform!")
               .Body(mailRequest.Body)
               .SendAsync();

            //using var smtp = new SmtpClient(); 

            //smtp.Connect(_mailSettings.Host, 25, false);
            //smtp.Send(email);
            //smtp.Disconnect(true);

        }
    }
}
