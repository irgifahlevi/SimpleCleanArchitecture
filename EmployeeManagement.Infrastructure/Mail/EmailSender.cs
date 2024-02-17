using EmployeeManagement.Application.Contracts.Infastructure;
using EmployeeManagement.Application.Models;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Infrastructure.Mail
{
    public class EmailSender : IEmailSender
    {
        private EmailSettings _emailSetings { get; }

        public EmailSender(IOptions<EmailSettings> emailSetings)
        {
            _emailSetings = emailSetings.Value;
        }
        public async Task<bool> SendEmail(Email email)
        {
            var client = new SendGridClient(_emailSetings.ApiKey);
            var to = new EmailAddress(email.To);
            var form = new EmailAddress
            { 
                Email = _emailSetings.FromAddress,
                Name = _emailSetings.FromName
            };

            var message = MailHelper.CreateSingleEmail(form, to, email.Subject, email.Body, email.Body);

            var response = await client.SendEmailAsync(message);

            if(response.IsSuccessStatusCode) 
            {
                return response.StatusCode == HttpStatusCode.OK;
            }

            return false;
        }
    }
}
