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
    }
}
