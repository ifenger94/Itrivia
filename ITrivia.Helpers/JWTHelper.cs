using ITrivia.Types.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using ITrivia.Contracts.Security;
using System.Net;

namespace ITrivia.Helpers
{
    public class JWTHelper : IJWTHelper
    {
        private readonly IConfiguration _configuration;
        private readonly byte[] _signingKey;
        private readonly SymmetricSecurityKey _symmetricSecurityKey;
        private readonly JwtSecurityTokenHandler _jwtSecurityHandler;

        public JWTHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            _signingKey = new byte[64];
            _symmetricSecurityKey = new SymmetricSecurityKey(_signingKey);
            _jwtSecurityHandler = new JwtSecurityTokenHandler();
        }

        public UserToken GenerateToken(string username, double minutes)
        {
            var userToken = new UserToken();
            var signingCredentials = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
            var expirationDate = DateTime.UtcNow.AddMinutes(minutes);

            // Create a new list of claims to be attached to the JWT Token
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, username), new Claim(ClaimTypes.Sid, Guid.NewGuid().ToString()) };

            // Create a new JWT Security Token
            var credentials = new JwtSecurityToken(claims: claims, expires: expirationDate, signingCredentials: signingCredentials);

            userToken.ExpirationDate = expirationDate;
            userToken.Token = _jwtSecurityHandler.WriteToken(credentials);

            return userToken;
        }

        public UserToken RefreshToken(string token, double minutes)
        {
            var claimsPrincipal = this.ValidateToken(token);
            var userClaim = claimsPrincipal.FindFirst(ClaimTypes.Name);
            IList<Claim> claims = new List<Claim>() { userClaim, new Claim(ClaimTypes.Sid, Guid.NewGuid().ToString()) };
            var expirationDate = DateTime.UtcNow.AddMinutes(minutes);
            var signingCredentials = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            var newCredentials = new JwtSecurityToken(claims: claims, expires: expirationDate, signingCredentials: signingCredentials);

            var userToken = new UserToken();
            userToken.ExpirationDate = expirationDate;
            userToken.Token = _jwtSecurityHandler.WriteToken(newCredentials);

            return userToken;
        }

        private ClaimsPrincipal ValidateToken(string jwtToken)
        {
            var tokenHandler = _jwtSecurityHandler;
            var validationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidAudience = _configuration["Audience"].ToString(),
                ValidIssuer = _configuration["Issuer"].ToString(),
                LifetimeValidator = this.LifetimeValidator,
                IssuerSigningKey = new SymmetricSecurityKey(_signingKey)
            };

            return tokenHandler.ValidateToken(jwtToken, validationParameters, out var validatedToken);
        }

        private bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters)
        {
            if (expires != null)
            {
                if (DateTime.UtcNow < expires) return true;
            }
            return false;
        }


    }
}
