# CoreStudyMaterial


Steps for FluentEmail API:
•	Install FluentEmail.Core     will be installed directly in case installed smtp first
•	Install FluentEmail.Smtp   to use smtp server
•	Install FluentEmail.Razor  to use templates in Email body

In Controller:
•	Configure Smtp
•	Prepare email Content and send

//this sender will send email file in the mentioned folder path
var sender = new SmtpSender(() => new SmtpClient("localhost")
            {
               DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
               PickupDirectoryLocation = @"D:\study\CoreStudyMaterial"          
});
            Email.DefaultSender = sender;

            await Email.From("oha_20@htmail.com")
                .Body("Hi, this is email sending sample")
                .To("sabdelaziz@ejada.com", "Enginer: Soha")
                .Subject("testing Title")
                .SendAsync();


Important note :
Must Choose SMTP endpoint that is joined amazon account to 
email-smtp.eu-north-1.amazonaws.com

