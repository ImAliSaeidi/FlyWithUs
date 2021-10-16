using FlyWithUs.Hosted.Service.Models;
using FlyWithUs.Hosted.Service.Models.Users;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FlyWithUs.Hosted.Service.Tools.Security
{
    public class TokenGenerator
    {
        public static string Generate(ApplicationUser user)
        {
            var claims = new List<Claim>();

            claims.Add(new Claim("UserId", user.Id));

            foreach (var applicationUserRoles in user.ApplicationUserRoles)
            {
                claims.Add(new Claim("role", applicationUserRoles.Role.Name));
            }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(12),
                Issuer = TokenConfig.Issuer,
                Audience = TokenConfig.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(TokenConfig.Key)), SecurityAlgorithms.HmacSha256Signature)
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
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(TokenConfig.Key))
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
