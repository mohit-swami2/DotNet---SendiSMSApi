using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace SMSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSComtroller : ControllerBase
    {

        private readonly ITwilioRestClient _client;
        public SMSComtroller(ITwilioRestClient client)
        {
            _client = client;
        }

        [HttpPost("Api-Send-smd")]
        public IActionResult SendSms(SmsMessage model)
        {
            var message = MessageResource.Create(
                to: new PhoneNumber(model.To),
                from: new PhoneNumber(model.From),
                body: model.Message,
                client: _client);
            return Ok("Success" + message.Sid); 
        }
    }
}
