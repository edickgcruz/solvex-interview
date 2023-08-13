using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Entities;

namespace BusinessLogic.Services
{
    public class ProductoService : IProductoService
    {
        private readonly ProductoDAL _productoDAL = new();
        
        public bool CrearProducto(Producto producto)
        {
            return _productoDAL.CrearProducto(producto);
        }

        public bool DeleteProduct(int id)
        {
            return _productoDAL.DeleteProduct(id);
        }

        public List<Producto> GetAllProducts()
        {
            return _productoDAL.GetAllProducts();
        }

        public IEnumerable<Producto> GetProducto(int id)
        {
            return _productoDAL.GetProducto(id);
        }

        public IEnumerable<Producto> GetProducto(string producto)
        {
            return _productoDAL.GetProducto(producto);
        }

        public bool UpdateProducto(int idProducto, Producto producto)
        {
            return _productoDAL.UpdateProducto(idProducto, producto);
        }
    }
}
