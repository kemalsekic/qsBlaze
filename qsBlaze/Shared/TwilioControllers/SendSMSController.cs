using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML;
using Twilio.AspNet.Core;
using Twilio.AspNet.Common;

namespace qsBlaze.Shared.TwilioControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SendSMSController : ControllerBase
    {
        string accountSid = "";
        string authToken = "";

        [HttpPost("SendText")]
        public ActionResult SendText(string phoneNumber)
        {

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "Hi there, this is QStack.  Your friends have invited you to play tennis today 4:00pm.\n\nReply 1 to join.\nReply 0 to let them know you won't make it.",
                from: new Twilio.Types.PhoneNumber("+13148977654"),
                to: new Twilio.Types.PhoneNumber("+1" + phoneNumber)
            );

            Console.WriteLine(message.Sid);

            return StatusCode(200, new { message = message.Sid });

        }
    }
}
