using FluentEmail.Core;
using FluentEmail.Razor;
using Microsoft.AspNetCore.Mvc;

namespace SampleCorePractice.Controllers
{
    [ApiController]
    [Route("[controller]/SendEmail")]
    public class EmailSending : ControllerBase
    {
        readonly IConfiguration _configuration;
        readonly IFluentEmail _mailer;

        public EmailSending(IConfiguration configuration, IFluentEmail mailer)
        {
            _configuration = configuration;
            _mailer = mailer;
        }

        [HttpGet]
        public async Task SendEmail()
        {
            ////to export email file to the mentioned directory and setting in place

            //var sender = new SmtpSender(() => new SmtpClient(_configuration.GetValue<string>("SES:SMTP"))
            //{
            //    UseDefaultCredentials = false,
            //    Port = _configuration.GetValue<int>("SES:Port"),
            //    Credentials = new NetworkCredential(_configuration.GetValue<string>("SES:Username")
            //    , _configuration.GetValue<string>("SES:Password")),
            //    EnableSsl = true
            //    //DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
            //    //PickupDirectoryLocation = @"D:\study\CoreStudyMaterial"
            //});
            //Email.DefaultSender = sender;


            //************************************************************************************
            //2- call mailer based on settings pre defined in program with plain text body

            //await _mailer.SetFrom(_configuration.GetValue<string>("Mail:FromEmail"))
            //    .Body("Hi, this is email sending sample without template")
            //    .To("sabdelaziz@ejada.com", "Enginer: Soha")
            //    .Subject("testing Title")
            //    .SendAsync();

            //************************************************************************************
            //3- call mailer based on settings pre defined in program with template body

            Email.DefaultRenderer = new RazorRenderer();
            await Email.From(_configuration.GetValue<string>("Mail:FromEmail"))
             .UsingTemplateFromFile($"{Directory.GetCurrentDirectory()}/TestEmail.cshtml",
              new TestEmailModel { Name = "Soha Sue" })
             .To("sabdelaziz@ejada.com", "Enginer: Soha")
             .Subject("testing Title")
             .SendAsync();


        }
    }
}
