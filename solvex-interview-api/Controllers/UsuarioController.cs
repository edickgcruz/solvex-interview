using BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;
using solvex_interview_api.DTOs;
using Entities;
using System.Xml;

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
            if (estaCreado) return Created(string.Empty, new { message = "El usuario fue creado correctamente.", estaCreado });

            return BadRequest();
        }

        [HttpGet("{username}")]
        public ActionResult GetUsuarioByUsername(string username)
        {
            var foundUsuario = _usuarioService.GetUsuarioByUsername(username);
            if (foundUsuario == null) return NotFound(new { message = "El usuario no fue encontrado" });
            return Ok(foundUsuario);
        }

        [HttpGet]
        public ActionResult<UsuarioDto> GetAllUser()
        {
            IEnumerable<Usuario> usuarios = _usuarioService.GetAllUser();
            List<UsuarioDto> listaUsuarios = new List<UsuarioDto>();

            if (usuarios != null)
            {
                foreach (var usuario in usuarios)
                {
                    listaUsuarios.Add(new UsuarioDto() { Username = usuario.Username, Password = usuario.Password, Rol = usuario.Rol });
                }
            }

            if (listaUsuarios == null) return NotFound();
            return Ok(listaUsuarios);
        }

        [HttpPut("{username}")]
        public ActionResult<UsuarioDto> UpdateUsuario([FromBody] UsuarioDto usuario)
        {
            var usuarioExiste = _usuarioService.GetUsuarioByUsername(usuario.Username);
            if (usuarioExiste == null)
            {
                return NotFound(new { message = "El usuario no fue encontrado, no puede ser actualizado"});
            }
                        
            var actualizarUsuario = new Usuario()
            {
                Username = usuario.Username,
                Password = usuario.Password,
                Rol = usuario.Rol
            };

            bool isUpdated = _usuarioService.UpdateUsuario(actualizarUsuario);
            if (!isUpdated)
            {
                throw new Exception("El usuario no pudo ser actualziado, algo ha salido mal");
            }

            return Ok(new { message = "El usuario fue actualziado correctamente."});
        }

        [HttpDelete("{username}")]
        public ActionResult DeleteUsuario(string username)
        {
            var usuarioExiste = _usuarioService.GetUsuarioByUsername(username);
            if (usuarioExiste == null)
            {
                return NotFound();
            }

            bool isDeleted = _usuarioService.DeleteUsuario(username);
            if (!isDeleted)
            {
                throw new Exception("El usuario no pudo ser borrado, algo ha salido mal");
            }

            return NoContent();
        }       
    }
}
