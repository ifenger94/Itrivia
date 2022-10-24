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
        private readonly SymmetricSecurityKey _symmetricSecurityKey;

        public JWTHelper()
        {
            _symmetricSecurityKey = new SymmetricSecurityKey(ConstantsHelper.KeyForHmacSha256);
        }

        public UserToken GenerateToken(string username, double minutes)
        {
            var userToken = new UserToken();
            var signingCredentials = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
            var expirationDate = DateTime.UtcNow.AddMinutes(minutes);

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, username), new Claim(ClaimTypes.Sid, Guid.NewGuid().ToString()) };

            var credentials = new JwtSecurityToken(
                claims: claims,
                expires: expirationDate,
                signingCredentials: signingCredentials,
                issuer: ConstantsHelper.TokenIssuer,
                audience: ConstantsHelper.TokenAudience);
            
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            
            userToken.ExpirationDate = expirationDate;
            userToken.Token = tokenHandler.WriteToken(credentials);

            return userToken;
        }

        public UserToken RefreshToken(string jwt, double minutes)
        {
            ClaimsPrincipal claimPrincipal = ValidateToken(jwt);
            DateTime expirationDate = DateTime.UtcNow.AddMinutes(minutes);
            Claim userNameClaim = claimPrincipal.FindFirst(ClaimTypes.Name);
            List<Claim> claims = new List<Claim> { userNameClaim, new Claim(ClaimTypes.Sid, Guid.NewGuid().ToString()) };
            var securityKey = new SymmetricSecurityKey(ConstantsHelper.KeyForHmacSha256);
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken token = tokenHandler
                .CreateToken(BuildSecurityTokenDescriptor(signingCredentials, claims, expirationDate));

            return new UserToken
            {
                ExpirationDate = expirationDate,
                Token = tokenHandler.WriteToken(token)
            };
        }

        private ClaimsPrincipal ValidateToken(string jwtToken)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            TokenValidationParameters validationParams =
                new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudience = ConstantsHelper.TokenAudience,
                    ValidIssuer = ConstantsHelper.TokenIssuer,
                    LifetimeValidator = this.LifetimeValidator,
                    IssuerSigningKey = new SymmetricSecurityKey(ConstantsHelper.KeyForHmacSha256)
                };
            SecurityToken dummyJwt;

            return tokenHandler.ValidateToken(jwtToken, validationParams, out dummyJwt);
        }

        private bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters)
        {
            if (expires != null)
            {
                if (DateTime.UtcNow < expires) return true;
            }
            return false;
        }

        private SecurityTokenDescriptor BuildSecurityTokenDescriptor(SigningCredentials securityKey, List<Claim> claims, DateTime expirationDate)
        {
            return new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = expirationDate,
                Issuer = ConstantsHelper.TokenIssuer,
                Audience = ConstantsHelper.TokenAudience,
                SigningCredentials = securityKey
            };
        }


    }
}
