using BusinessLogic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using solvex_interview_api.DTOs;
using Entities;

namespace solvex_interview_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService) 
        { 
            _usuarioService = usuarioService;
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

        [HttpPost("login")]
        public IActionResult ValidarLoginUsuario([FromBody] UsuarioLoginDto usuarioLoginDto)
        {
            var usuarioValidar = new Usuario()
            {
                Username = usuarioLoginDto.Username,
                Password = usuarioLoginDto.Password
            };

            var usuarioExistente = _usuarioService.ValidarUsuarioCredenciales(usuarioValidar);
            if(!usuarioExistente.Any()) return Unauthorized("Usuario no autorizado.");

            return Ok("Credenciales correctas");
        }
    }
}
