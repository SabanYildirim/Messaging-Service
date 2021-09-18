using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MessagingServiceApp.Common.Utilities
{
    public class JwtToken
    {
        public String GenerateToken(string username,string JwtSecurityKey, string JwtExpireInDays, string JwtAudience, string JwtIssuer)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSecurityKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(int.Parse(JwtExpireInDays));
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,username)
            };

            var token = new JwtSecurityToken(JwtIssuer, JwtAudience, claims, null, expiry, creds);
            String tokenStr = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenStr;
        }
    }
}
