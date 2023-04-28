using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Accompany_consulting.Models;

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

        [HttpPost]
        public async Task<IActionResult> SendEmail(EmailMessage emailMessage)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(emailMessage.FromName, emailMessage.FromEmail));
            message.To.Add(new MailboxAddress(emailMessage.ToName, emailMessage.ToEmail));
            message.Subject = emailMessage.Subject;

            message.Body = new TextPart("html")
            {
                Text = emailMessage.Body
            };

            using var client = new SmtpClient();
            await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(_config["Gmail:Username"], _config["Gmail:Password"]);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);

            return Ok();
        }
    }


}