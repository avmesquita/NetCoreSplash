using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace NetCoreSplash.APImenta.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(string To, string subject, string body);
    }
}
