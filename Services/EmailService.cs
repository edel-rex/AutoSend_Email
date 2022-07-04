using System;
using AutoSend_Email.Interface;
using AutoSend_Email.Models;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System.Net.Mail;
using System.Net;

namespace AutoSend_Email.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        public EmailService(IConfiguration configuration)
        {
            _config = configuration;
        }
        public void SendEmail(Email request)
        {
            var email = new MailMessage();
            email.To.Add(request.To.Trim());
            email.From = new MailAddress(_config["Email:userID"], "Edel");
            email.Subject = request.Subject;
            email.Body = request.Body;
            email.Priority = MailPriority.Normal;
            // email.From.Add(MailboxAddress.Parse(_config["Email:userID"]));
            // email.To.Add(MailboxAddress.Parse(request.To));
            // email.Subject = request.Subject;
            // email.Body = new TextPart(TextFormat.Text) {Text = request.Body};

            SmtpClient smtp = new SmtpClient();
            smtp.Host = _config["Email:host"];
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(_config["Email:userID"], _config["Email:password"]);
            // smtp.Connect(_config["Email:host"], 587, SecureSocketOptions.StartTls);
            // smtp.Authenticate(_config["Email:userID"],_config.GetSection("Email").GetSection("password").Value);
            smtp.Send(email);
            // smtp.Disconnect(true);
        }
    }
}
