using Accompany_consulting.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
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
        private readonly EmailConfiguration _emailConfiguration;

        public EmailController(IConfiguration config, IOptions<EmailConfiguration> emailConfiguration)
        {
            _config = config;
            _emailConfiguration = emailConfiguration.Value;
        }

        [HttpPost("SendEmail")]
        public async Task<IActionResult> SendEmail(EmailMessage emailMessage)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("SI RH", _emailConfiguration.Username));
                message.To.Add(new MailboxAddress(emailMessage.ToName, emailMessage.ToEmail));
                message.Subject = emailMessage.Subject;

             


                message.Cc.Add(new MailboxAddress(_emailConfiguration.NameCc, _emailConfiguration.EmailCc));

                // Add additional CC addresses from the provided emailMessage.CcEmail
                if (!string.IsNullOrEmpty(emailMessage.CcEmail))
                {
                    var additionalCcAddresses = emailMessage.CcEmail.Split(';');
                    foreach (var ccAddress in additionalCcAddresses)
                    {
                        if (!string.IsNullOrEmpty(ccAddress.Trim()))
                        {
                            message.Cc.Add(new MailboxAddress("", ccAddress.Trim()));
                        }
                    }
                }
                message.Body = new TextPart("html")
                {
                    Text = emailMessage.Body
                };

                using var client = new SmtpClient();

                // Utilisez les paramètres de configuration au lieu de les codifier ici
                string smtpServer = _emailConfiguration.SmtpServer;
                int smtpPort = _emailConfiguration.SmtpPort;

                await client.ConnectAsync(smtpServer, smtpPort, SecureSocketOptions.StartTls);

                try
                {
                    await client.AuthenticateAsync(_emailConfiguration.Username, _emailConfiguration.Password);
                }
                catch (MailKit.Security.AuthenticationException authEx)
                {
                    return StatusCode(500, $"Échec de l'authentification sur {smtpServer}: {authEx.Message}");
                }

                try
                {
                    await client.SendAsync(message);
                }
                catch (MailKit.Net.Smtp.SmtpCommandException smtpEx)
                {
                    return StatusCode(550, $"Échec de l'envoi de l'e-mail sur {smtpServer}: {smtpEx.Message}");
                }

                await client.DisconnectAsync(true);

                if (!client.IsConnected)
                {
                    return StatusCode(560, $"Échec de l'envoi de l'e-mail sur {smtpServer}.");
                }
                else
                {
                    return Ok("E-mail envoyé avec succès.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite : {ex.Message}");
            }
        }


        [HttpPost("SendEmailsanscc")]
        public async Task<IActionResult> SendEmailsanscc(EmailMessage emailMessage)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("SI RH", _emailConfiguration.Username));
                message.To.Add(new MailboxAddress(emailMessage.ToName, emailMessage.ToEmail));
                message.Subject = emailMessage.Subject;




                // Add additional CC addresses from the provided emailMessage.CcEmail
                if (!string.IsNullOrEmpty(emailMessage.CcEmail))
                {
                    var additionalCcAddresses = emailMessage.CcEmail.Split(';');
                    foreach (var ccAddress in additionalCcAddresses)
                    {
                        if (!string.IsNullOrEmpty(ccAddress.Trim()))
                        {
                            message.Cc.Add(new MailboxAddress("", ccAddress.Trim()));
                        }
                    }
                }
                message.Body = new TextPart("html")
                {
                    Text = emailMessage.Body
                };

                using var client = new SmtpClient();

                // Utilisez les paramètres de configuration au lieu de les codifier ici
                string smtpServer = _emailConfiguration.SmtpServer;
                int smtpPort = _emailConfiguration.SmtpPort;

                await client.ConnectAsync(smtpServer, smtpPort, SecureSocketOptions.StartTls);

                try
                {
                    await client.AuthenticateAsync(_emailConfiguration.Username, _emailConfiguration.Password);
                }
                catch (MailKit.Security.AuthenticationException authEx)
                {
                    return StatusCode(500, $"Échec de l'authentification sur {smtpServer}: {authEx.Message}");
                }

                try
                {
                    await client.SendAsync(message);
                }
                catch (MailKit.Net.Smtp.SmtpCommandException smtpEx)
                {
                    return StatusCode(550, $"Échec de l'envoi de l'e-mail sur {smtpServer}: {smtpEx.Message}");
                }

                await client.DisconnectAsync(true);

                if (!client.IsConnected)
                {
                    return StatusCode(560, $"Échec de l'envoi de l'e-mail sur {smtpServer}.");
                }
                else
                {
                    return Ok("E-mail envoyé avec succès.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite : {ex.Message}");
            }
        }
    }
}
