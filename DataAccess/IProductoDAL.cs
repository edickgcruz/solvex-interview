using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IProductoDAL
    {
        public bool CrearProducto(Producto producto);
    }
}
