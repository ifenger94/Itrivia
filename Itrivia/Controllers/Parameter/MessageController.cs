using ITrivia.Contracts.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Itrivia.WebApi.Controllers.Parameter
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private IMessageDomain messageDomain;

        public MessageController(IMessageDomain messageDomain)
        {
            this.messageDomain = messageDomain;
        }

        [HttpGet]
        public IDictionary<string, string> Get(string id)
        {
            return messageDomain.GetMessages(id);
        }
    }
}
