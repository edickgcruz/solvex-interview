using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using solvex_interview_api.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace solvex_interview_api
{
    public class TokenJwt
    {
        private IConfiguration config;

        public TokenJwt()
        {
            
        }

        public TokenJwt(IConfiguration configuration)
        {
            config = configuration;
        }
        public string GenerateToken(UsuarioLoginDto usuarioLoginDto)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, usuarioLoginDto.Username),
                //new Claim(ClaimTypes.Email, admin.Email),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetSection("JWT:Key").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: creds);

            string token = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return token;
        }
    }
}
