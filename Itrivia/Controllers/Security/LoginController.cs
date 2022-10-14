using ITrivia.Contracts.Domain;
using ITrivia.Contracts.Security;
using ITrivia.Helpers;
using ITrivia.Types.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Itrivia.WebApi.Controllers.Security
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserDomain userDomain;
        private readonly IRolDomain rolDomain;
        private readonly IConfiguration configuration;
        private readonly IJWTHelper jwtHelper;

        public LoginController(IUserDomain userDomain, IRolDomain rolDomain, IConfiguration configuration, IJWTHelper jwtHelper)
        {
            this.userDomain = userDomain;
            this.rolDomain = rolDomain;
            this.configuration = configuration;
            this.jwtHelper = jwtHelper;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate([FromBody] UserCredentials userCredentials)
        {
            try
            {
                if (userCredentials is null)
                {
                    return BadRequest();
                }

                var user = userDomain.GetByEmail(userCredentials.Email);

                if (user is null)
                {
                    return BadRequest();
                }

                if (HashHelper.CheckHash(userCredentials.Password, user.Password))
                {
                    var authData = new AuthData()
                    {
                        UserID = user.Id,
                        RolCode = rolDomain.GetRolCodeById(user.IdRol),
                        ProfileID = user.IdPerfil,
                        JWT = jwtHelper.GenerateToken(user.Email, configuration.GetValue<double>("JWTExpirationInMinutes")).ToString()
                    };

                    return new OkObjectResult(authData);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {

                return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError); 
            }
            

        }
    }
}
