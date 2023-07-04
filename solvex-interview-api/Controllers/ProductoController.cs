using BusinessLogic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using solvex_interview_api.DTOs;
using Entities;

namespace solvex_interview_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;
        public ProductoController(IProductoService productoService) 
        {
            _productoService = productoService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ProductoOutputDto>> GetAllProducts()
        {
            var producto = _productoService.GetAllProducts().Select( producto => new ProductoOutputDto() { Id = producto.Id, Name = producto.Name});
            return Ok(producto);
        }

        [HttpPost]
        public ActionResult Create(ProductoDto productoDto)
        {
            var nuevoProducto = new Producto()
            {
                Name = productoDto.Name
            };
            bool estaGuardado = _productoService.CrearProducto(nuevoProducto);
            if (estaGuardado) return Ok(new {message = "El producto fue guardado correctamente", estaGuardado });

            return BadRequest(new { message = "El producto no ha sido guardado", estaGuardado });
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            bool estaEliminado = _productoService.DeleteProduct(id);
            if (estaEliminado) return Ok(new { message = "El producto fue eliminado correctamente.", estaElimnado = estaEliminado});

            return BadRequest(new { message = "El producto no pudo ser eliminado"});
        }
    }
}
