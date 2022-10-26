using ITrivia.Contracts.Domain;
using ITrivia.Types.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Itrivia.WebApi.Controllers.Security
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RolController:ControllerBase
    {
        private readonly IRolDomain _rolDomain;

        public RolController(IRolDomain rolDomain)
        {
            this._rolDomain = rolDomain;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id != 0)
                {
                    SegProle rol = _rolDomain.Get(id);
                    if (rol != null) return Ok(rol);
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
