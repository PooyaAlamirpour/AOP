using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Core.Authentication.JWT;
using Core.Concretes;
using Core.Extensions;
using Core.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Core.Security.JWT
{
    public class TokenHelper : ITokenHelper
    {
        private DateTime _accessTokenExpiration;
        private readonly TokenOptions _tokenOptions;

        public TokenHelper(IConfiguration configuration)
        {
            _tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var key = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredential = SigningCredentialHelper.CreateSigningCredential(key);
            var jwt = CreatJwtSecurityToken(user, signingCredential, operationClaims);
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtTokenHandler.WriteToken(jwt);

            return new AccessToken()
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
        }

        public JwtSecurityToken CreatJwtSecurityToken(User user, SigningCredentials signingCredentials,
            IEnumerable<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer:_tokenOptions.Issuer, 
                audience:_tokenOptions.Audience, 
                SetClaim(user, operationClaims), 
                notBefore: DateTime.Now, 
                expires: _accessTokenExpiration, 
                signingCredentials: signingCredentials);
            return jwt;
        }
        
        private IEnumerable<Claim> SetClaim(User user, IEnumerable<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddEmail(user.Email);
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddName($"{user.FirstName}.{user.LastName}");
            claims.AddRoles(operationClaims.Select(x => x.Name));

            return claims;
        }
    }
}