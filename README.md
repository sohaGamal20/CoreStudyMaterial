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

***********************************************************************************************
sending SMS using Twiio Provider:
from Twilio Portal:
https://www.twilio.com/
1- Create new account
2- Add new Virtual Phone number
3- copy SID and Auth token and US. phone number 

in Visual Studio project :
1- from package manager, add Twilio 
2- add new section in app settings, 
  "Twilio": {
    "AccountSID": "",
    "AuthToken": "",
    "phoneNumber": ""
  }
 
 3- add new class contains the same variables names as in app settings
 and register it in programs as well
   builder.Services.Configure<TwilioSettings>(builder.Configuration.GetSection("Twilio"));
 
 4- add new interface and class to implement it having sendmessage method
 5- register service to be able to use it in controller
	builder.Services.AddTransient<ITwilioSMS, TwilioSMS>();
	
6- consume service from controller 	


Resources:
https://youtu.be/LOld80JBOgA
https://www.twilio.com/docs/sms/send-messages

***********************************************************************************************