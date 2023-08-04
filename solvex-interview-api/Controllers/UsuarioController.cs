using BusinessLogic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using solvex_interview_api.DTOs;
using Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace solvex_interview_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IConfiguration config;
        public UsuarioController(IUsuarioService usuarioService, IConfiguration configuration) 
        { 
            _usuarioService = usuarioService;
            config = configuration;
        }

        [HttpPost]
        public IActionResult CrearUsuario([FromBody] UsuarioDto usuario)
        {
            var nuevoUsuario = new Usuario() 
            {
                Username = usuario.Username,
                Password = usuario.Password,
                Rol = usuario.Rol
            };

            bool estaCreado = _usuarioService.CrearUsuario(nuevoUsuario);
            if (estaCreado) return Created(string.Empty, new { message = "El usuario fue creado correctamente.", estaCreado});

            return BadRequest();
        }

        //[HttpPost("login")]
        //public IActionResult ValidarLoginUsuario([FromBody] UsuarioLoginDto usuarioLoginDto)
        //{
        //    var usuarioValidar = new Usuario()
        //    {
        //        Username = usuarioLoginDto.Username,
        //        Password = usuarioLoginDto.Password
        //    };

        //    var usuarioExistente = _usuarioService.ValidarUsuarioCredenciales(usuarioValidar);
        //    if(!usuarioExistente.Any()) return Unauthorized("Usuario no autorizado.");

        //    string? token = GenerateToken(new UsuarioLoginDto() { Username = usuarioValidar.Username, Password = usuarioValidar.Password });

        //    if(token != null) return Ok(new { message = "Credenciales correctas", token = token });
        //    return NotFound();
        //}

        //// Metodo para generar el token mediante JWT, este es parte del proceso de login
        //private string GenerateToken(UsuarioLoginDto usuarioLoginDto)
        //{
        //    var claims = new[]
        //    {
        //        new Claim(ClaimTypes.Name, usuarioLoginDto.Username),
        //        //new Claim(ClaimTypes.Email, admin.Email),
        //    };

        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetSection("JWT:Key").Value));
        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        //    var securityToken = new JwtSecurityToken(
        //        claims: claims,
        //        expires: DateTime.Now.AddMinutes(60),
        //        signingCredentials: creds);

        //    string token = new JwtSecurityTokenHandler().WriteToken(securityToken);

        //    return token;
        //}
        //// Metodo para generar el token mediante JWT, este es parte del proceso de login
    }
}
