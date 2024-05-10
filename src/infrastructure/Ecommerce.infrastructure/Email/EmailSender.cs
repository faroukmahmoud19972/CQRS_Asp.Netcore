using Ecommerce.Application.Models.Email;
using Ecommerce.Application.Presistance.Email;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.infrastructure.Email
{
    public class EmailSender : IEmailSender
    {
        public EmailSettings _emailSettings { get; }    

        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }
        public async Task<bool> SendEmail(EmailMessage email)
        {
            var client = new SendGridClient(_emailSettings.ApiKey);
            var to = new EmailAddress(email.To);
            var from = new EmailAddress()
            {
                Email = _emailSettings.FromAddress,
                Name = _emailSettings.FromName,
            };
            var message = MailHelper.CreateSingleEmail(from  , to, email.subject , email.Body , email.Body );
            var res =await client.SendEmailAsync(message);

            return res.StatusCode ==System.Net.HttpStatusCode.OK || res.StatusCode == System.Net.HttpStatusCode.Accepted ;



        }
    }
}
