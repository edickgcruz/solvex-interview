using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface IUsuarioService
    {
        public bool CrearUsuario(Usuario usuario);
        public IEnumerable<Usuario> ValidarUsuarioCredenciales(Usuario usuario);
    }
}
