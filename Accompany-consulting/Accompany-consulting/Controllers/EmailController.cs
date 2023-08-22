using Accompany_consulting.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Threading.Tasks;

namespace Accompany_consulting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IConfiguration _config;

        public EmailController(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IActionResult> SendEmail(EmailMessage emailMessage)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(emailMessage.FromName, emailMessage.FromEmail));
            message.To.Add(new MailboxAddress(emailMessage.ToName, emailMessage.ToEmail));
            message.Subject = emailMessage.Subject;

            if (!string.IsNullOrEmpty(emailMessage.CcEmail))
            {
                message.Cc.Add(new MailboxAddress(emailMessage.CcName, emailMessage.CcEmail));
            }

            message.Body = new TextPart("html")
            {
                Text = emailMessage.Body
            };

            using var client = new SmtpClient();
            await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(_config["Gmail:Username"], _config["Gmail:Password"]);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);

            if (!client.IsConnected)
            {
                // L'e-mail n'a pas pu être envoyé
                Console.WriteLine("Échec de l'envoi de l'e-mail.");
            }
            else
            {
                // L'e-mail a été envoyé avec succès
                Console.WriteLine("E-mail envoyé avec succès.");
            }

            return Ok();
        }

    }


}