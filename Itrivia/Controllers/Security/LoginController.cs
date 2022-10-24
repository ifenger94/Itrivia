using Itrivia.WebApi.Helpers;
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
        [HttpPost("Authenticate")]
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

                if ((HashHelper.CheckHash(userCredentials.Password, user.Password)))
                {
                    UserToken userToken = jwtHelper.GenerateToken(user.Email, configuration.GetValue<double>("JWTExpirationInMinutes"));
                    var authData = new AuthData()
                    {
                        UserId = user.Id,
                        RolCode = rolDomain.GetRolCodeById(user.IdRol),
                        ProfileId = user.IdPerfil,
                        Jwt = userToken.Token,
                        LifeTime = userToken.ExpirationDate
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

        [HttpGet("RefreshToken")]
        public IActionResult RefreshToken()
        {
            try
            {
                string oldToken = JwtManagmentHelper.RetrieveAuthorizationFromHeader(Request);
                UserToken userToken = jwtHelper.RefreshToken(oldToken, configuration.GetValue<double>("JWTRefreshExpirationInMinutes"));
                UserToken authData = new UserToken()
                {
                    Token = userToken.Token,
                    ExpirationDate = userToken.ExpirationDate
                };

                return Ok(userToken);
            }
            catch (Exception e)
            {

                return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
