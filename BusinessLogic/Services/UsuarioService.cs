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

        public IEnumerable<Usuario> GetAllUser()
        {
            return _usuarioDAL.GetAllUsers();
        }

        public IEnumerable<Usuario> ValidarUsuarioCredenciales(Usuario usuario)
        {
            return _usuarioDAL.ValidarUsuarioCredenciales(usuario);
        }

        public IEnumerable<Usuario> GetUsuarioByUsername(string username)
        {
            return _usuarioDAL.GetUserByUsername(username);
        }

        public bool UpdateUsuario(Usuario usuario)
        {
            return _usuarioDAL.UpdateUsuario(usuario);
        }

        public bool DeleteUsuario(string username)
        {
            return _usuarioDAL.DeleteUsuario(username);
        }
    }
}
