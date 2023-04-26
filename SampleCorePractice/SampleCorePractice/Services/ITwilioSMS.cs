using Twilio.Rest.Api.V2010.Account;

namespace SampleCorePractice.Services
{
    public interface ITwilioSMS
    {
        public MessageResource SendSMS(string phone, string body);
    }
}
