using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DBStore.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }

        //private readonly string _sendGridApiKey;
        //private readonly string _senderAddress;
        //private readonly string _senderName;

        //public EmailSender(IConfiguration config)
        //{
        //    var configSection = config.GetSection("SendGrid");

        //    _sendGridApiKey = configSection["APIKey"];
        //    _senderAddress = configSection["SenderAddress"];
        //    _senderName = configSection["SenderName"];
        //}
        //public Task SendEmailAsync(string recipient, string subject, string htmlMessage)
        //{
        //    return Execute(recipient, subject, htmlMessage);
        //}

        //private Task Execute(string recipient, string subject, string htmlMessage)
        //{
        //    var client = new SendGridClient(_sendGridApiKey);
        //    var msg = new SendGridMessage
        //    {
        //        From = new EmailAddress(_senderAddress, _senderName),
        //        Subject = subject,
        //        HtmlContent = htmlMessage,
        //        PlainTextContent = htmlMessage,
        //    };

        //    msg.AddTo(new EmailAddress(recipient));
        //    msg.SetClickTracking(false, false);

        //    return client.SendEmailAsync(msg);
        //}

    }
}
