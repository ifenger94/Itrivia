using ITrivia.Contracts.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Itrivia.WebApi.Controllers.Parameter
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private IMessageDomain messageDomain;

        public MessagesController(IMessageDomain messageDomain)
        {
            this.messageDomain = messageDomain;
        }

        [HttpGet("{id}")]
        public IDictionary<string, string> Get(string id)
        {
            return messageDomain.GetMessages(id);
        }
    }
}
