using NetCoreSplash.APImenta.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace NetCoreSplash.APImenta.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendAsync(string To, string subject, string body)
        {
            using (var smtp = new SmtpClient())
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 993;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("", "");
                
                var message = new MailMessage
                {
                    Body = body,
                    Subject = subject,
                    From = new MailAddress("", ""),
                    IsBodyHtml = true
                };                
                message.To.Add(To);
                await smtp.SendMailAsync(message);
            }
        }
    }
}
