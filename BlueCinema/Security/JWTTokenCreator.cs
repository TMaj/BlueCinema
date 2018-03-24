using BlueCinema.Helpers.Extensions;
using BlueCinema.Models.ViewModels;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlueCinema.Security
{
    public static class JWTTokenCreator
    {
        public static string GetToken(LoginViewModel loginViewModel, IList<Claim> claims)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("qwertyuiopqwertyuiop"));

            claims.AddRange(new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, loginViewModel.Email)
            });

            var token = new JwtSecurityToken(
                issuer: "BlueCinema",
                audience: "BlueCinemaClient",
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddDays(28),
                signingCredentials: new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256)
            );

            // return token;
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
