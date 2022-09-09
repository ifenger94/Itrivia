using ITrivia.Contracts.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Itrivia.WebApi.Controllers.Parameter
{
    [ApiController]
    [Route("[controller]")]
    public class LabelController : ControllerBase
    {

        private ILabelDomain _labelDomain;

        public LabelController(ILabelDomain labelDomain)
        {
            _labelDomain = labelDomain;
        }

        [HttpGet]
        public IDictionary<string, string> Get(string id)
        {
            return _labelDomain.GetLabels(id);
        }
    }
}
