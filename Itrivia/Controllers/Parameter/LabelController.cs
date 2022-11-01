using ITrivia.Contracts.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Itrivia.WebApi.Controllers.Parameter
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class LabelController : ControllerBase
    {

        private ILabelDomain _labelDomain;

        public LabelController(ILabelDomain labelDomain)
        {
            _labelDomain = labelDomain;
        }

        [HttpGet("{id}")]
        public IDictionary<string, string> Get(string id)
        {
            return _labelDomain.GetLabels(id);
        }
    }
}
