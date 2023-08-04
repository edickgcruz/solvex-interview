using BusinessLogic.Services;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using solvex_interview_api.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace solvex_interview_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IConfiguration config;
        public LoginController(IUsuarioService usuarioService, IConfiguration configuration)
        {
            _usuarioService = usuarioService;
            config = configuration;
        }
        [HttpPost]
        public IActionResult ValidarLoginUsuario([FromBody] UsuarioLoginDto usuarioLoginDto)
        {
            var usuarioValidar = new Usuario()
            {
                Username = usuarioLoginDto.Username,
                Password = usuarioLoginDto.Password,
                Rol = usuarioLoginDto.Rol
            };

            var usuarioExistente = _usuarioService.ValidarUsuarioCredenciales(usuarioValidar);
            if (!usuarioExistente.Any()) return Unauthorized("Usuario no autorizado.");

            string? token = GenerateToken(new UsuarioLoginDto() { Username = usuarioValidar.Username, Password = usuarioValidar.Password, Rol = usuarioValidar.Rol });

            if (token != null) return Ok(new { message = "Credenciales correctas", token = token });
            return NotFound();
        }

        // Metodo para generar el token mediante JWT, este es parte del proceso de login
        private string GenerateToken(UsuarioLoginDto usuarioLoginDto)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, usuarioLoginDto.Username),
                new Claim(ClaimTypes.Role, usuarioLoginDto.Rol)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetSection("JWT:Key").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                //expires: DateTime.Now.AddMinutes(1),

                signingCredentials: creds);

            string token = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return token;
        }
        // Metodo para generar el token mediante JWT, este es parte del proceso de login
    }
}
