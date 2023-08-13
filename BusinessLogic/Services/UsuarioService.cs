using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace BusinessLogic.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly UsuarioDAL _usuarioDAL = new UsuarioDAL();
        public bool CrearUsuario(Usuario usuario)
        {
            return _usuarioDAL.CrearUsuario(usuario);
        }

        public IEnumerable<Usuario> ValidarUsuarioCredenciales(Usuario usuario)
        {
            return _usuarioDAL.ValidarUsuarioCredenciales(usuario);
        }
    }
}
