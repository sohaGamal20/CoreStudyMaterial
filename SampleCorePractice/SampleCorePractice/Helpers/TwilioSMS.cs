using Microsoft.Extensions.Options;
using SampleCorePractice.Services;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace SampleCorePractice.Helpers
{
    public class TwilioSMS : ITwilioSMS
    {
        private readonly TwilioSettings _twilio;

        public TwilioSMS(IOptions<TwilioSettings> twilio)
        {
            _twilio = twilio.Value;
        }

        public MessageResource SendSMS(string phone, string body)
        {
            TwilioClient.Init(_twilio.AccountSID, _twilio.AuthToken);

            var result = MessageResource.Create(to:phone,
                body:body,
                from:new Twilio.Types.PhoneNumber(_twilio.phoneNumber));
            return result;
        }
    }
}
