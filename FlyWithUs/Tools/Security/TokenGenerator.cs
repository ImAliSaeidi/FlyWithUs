using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FlyWithUs.Hosted.Service.Tools.Security
{
    public class TokenGenerator
    {
        public static string Generate(IdentityUser user)
        {
            Claim userid = new Claim("UserId", user.Id);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { userid }),
                Expires = DateTime.Now.AddHours(1),
                Issuer = "www.FlyWithUs.ir",
                Audience = "www.FlyWithUs.ir",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("eY RoOz B@R A K Z@rE ha RAGHS KONAND")), SecurityAlgorithms.HmacSha256Signature)
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var securitytoken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(securitytoken);
        }

        public static ClaimsPrincipal Validate(string token)
        {
            var parameters = new TokenValidationParameters()
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireExpirationTime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("eY RoOz B@R A K Z@rE ha RAGHS KONAND"))
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            if (tokenHandler.CanReadToken(token))
            {
                return tokenHandler.ValidateToken(token, parameters, out SecurityToken securityToken);
            }
            return null;
        }
    }
}
