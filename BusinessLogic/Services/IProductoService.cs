using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface IProductoService
    {
        public bool CrearProducto(Producto producto);
        public List<Producto> GetAllProducts();
        public IEnumerable<Producto> GetProducto(int id);
        public IEnumerable<Producto> GetProducto(string id);
        public bool DeleteProduct(int id);
        public bool UpdateProducto(int idProducto, Producto producto);
    }
}
