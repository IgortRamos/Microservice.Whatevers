using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Microservice.Whatevers.WebApi.Services
{  
    public class JwtService  
    {  
        public static string _secret = "segredo1234567890segredo1234567890segredo1234567890";  
        public static short _expDate = 5;

        public string GenerateSecurityToken()  
        {
            var claimValue = Guid.NewGuid().ToString();//Id de user, por exemplo

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GetClaimsIdentity(claimValue),
                Expires = DateTime.UtcNow.AddMinutes(_expDate),
                SigningCredentials = GetSigningCredentials()
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private static ClaimsIdentity GetClaimsIdentity(string claimValue) =>
            new ClaimsIdentity(new[] { new Claim(ClaimTypes.Sid, claimValue) });

        private static SigningCredentials GetSigningCredentials() =>
            new SigningCredentials(GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256Signature);
        
        private static SymmetricSecurityKey GetSymmetricSecurityKey() {
            var secret = _secret;
            var key = Encoding.ASCII.GetBytes(secret);
            return new SymmetricSecurityKey(key);
        }
        
    }  
}