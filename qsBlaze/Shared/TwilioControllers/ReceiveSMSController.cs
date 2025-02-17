using Microsoft.AspNetCore.Mvc;
using DataAccessLibrary.Models.TSMS;
using Twilio;
using Twilio.AspNet.Core;
using Twilio.AspNet.Common;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML;
using Twilio.Types;
using DataAccessLibrary;
using DataAccessLibrary.Models;
using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Models.Teams;
using DataAccessLibrary.Interfaces.Games;

namespace qsBlaze.Shared.TwilioControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReceiveSMSController : TwilioController
    {
        IPlayerData _db;
        IPeopleData _db2;

        private async Task UpdatePlayerColor(string playerPhoneNum, string color)
        {
            PersonModel p = new PersonModel
            {
                PhoneNumber = playerPhoneNum
            };
            await _db2.EditPersonPhoneNumber(p);
        }

        [HttpPost("SendReply")]
        public TwiMLResult SendReply([FromForm] TwilioSMS request)
        {
            var response = new MessagingResponse();
            response.Message("QStack!\nCheckout our website to view who else is playing!");
            if (request.Body == "1")
            {
                response.Message("Welcome to QStack!  You have been added to the waitlist.\nCheckout our website to view who else is playing!\n\nhttps://qstack.azurewebsites.net/");
                string pNum = Request.Form["From"];
                string color = "Green";
                UpdatePlayerColor(pNum, color);
            }
            else if (request.Body == "0")
            {
                response.Message("That's alright, maybe next time! We'll let the team know you won't make it.\n\nhttps://qstack.azurewebsites.net/");
                string pNum = Request.Form["From"];
                string color = "Red";
                UpdatePlayerColor(pNum, color);
            }

            return TwiML(response);

        }
    }
}
