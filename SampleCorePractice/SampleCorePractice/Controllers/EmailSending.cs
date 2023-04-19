using FluentEmail.Core;
using FluentEmail.Smtp;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace SampleCorePractice.Controllers
{
    [ApiController]
    [Route("[controller]/SendEmail")]
    public class EmailSending : ControllerBase
    {
        [HttpGet]
        public async Task SendEmail()
        {
            var sender = new SmtpSender(() => new SmtpClient("localhost")
            {
                EnableSsl = false,
               DeliveryMethod=SmtpDeliveryMethod.Network,
               Port =993
                
                //DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
                //PickupDirectoryLocation = @"D:\study\CoreStudyMaterial"
            });
            Email.DefaultSender = sender;

            await Email.From("oha_20@htmail.com")
                .Body("Hi, this is email sending sample")
                .To("sabdelaziz@ejada.com", "Enginer: Soha")
                .Subject("testing Title")
                .SendAsync();

        }
    }
}
