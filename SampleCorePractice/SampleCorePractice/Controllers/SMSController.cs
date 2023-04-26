using Microsoft.AspNetCore.Mvc;
using SampleCorePractice.Dtos;
using SampleCorePractice.Services;

namespace SampleCorePractice.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class SMSController : ControllerBase
    {
        private readonly ITwilioSMS _twilio;

        public SMSController(ITwilioSMS twilio)
        {
            _twilio = twilio;
        }

        [HttpPost("send")]
        public IActionResult SendSMS(SMSDto sMS)
        {
            var result = _twilio.SendSMS(sMS.mobileNumber, sMS.body);
            if (!string.IsNullOrEmpty(result.ErrorMessage))
                return BadRequest(result.ErrorMessage);

            return Ok(result);  
        }
    }
}
