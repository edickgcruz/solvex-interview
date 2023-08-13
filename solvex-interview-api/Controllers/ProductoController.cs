using BusinessLogic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using solvex_interview_api.DTOs;
using Entities;
using Microsoft.AspNetCore.Authorization;

namespace solvex_interview_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;
        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        [Authorize(Roles = "admin, seller, user")]
        public ActionResult<IEnumerable<ProductoOutputDto>> GetAllProducts()
        {
            var producto = _productoService.GetAllProducts().Select(producto => new ProductoOutputDto() { Id = producto.Id, Name = producto.Name });
            return Ok(producto);
        }

        [HttpPost]
        [Authorize(Roles = "admin, seller")]
        public ActionResult Create(ProductoDto productoDto)
        {
            var nuevoProducto = new Producto()
            {
                Name = productoDto.Name
            };
            bool estaGuardado = _productoService.CrearProducto(nuevoProducto);
            if (estaGuardado) return Ok(new { message = "El producto fue guardado correctamente", estaGuardado });

            return BadRequest(new { message = "El producto no ha sido guardado", estaGuardado });
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public ActionResult Delete([FromRoute] int id)
        {
            // TODO: Debo de buscar el producto por Id antes de enviar a eliminarlo, asi controlo si existe o no desde un inicio

            bool estaEliminado = _productoService.DeleteProduct(id);
            if (estaEliminado) return Ok(new { message = "El producto fue eliminado correctamente.", estaElimnado = estaEliminado});

            return BadRequest(new { message = "El producto no pudo ser eliminado"});
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin, seller")]
        public ActionResult update([FromRoute] int id, [FromBody] ProductoUpdateDto productoDto)
        {
            var productoEncontrado = _productoService.GetProducto(id);

            if (productoDto == null)
            {
                return BadRequest(new { message = "Los datos para actualizar no fueron provistos.", estaActualizado = false });
            }

            if (productoEncontrado == null || !productoEncontrado.Any())
            {
                return NotFound(new { message = "El producto indicado no existe.", estaActualizado = false });
            }
            
            var producto = new Producto()
            {
                Id = productoDto.Id,
                Name = productoDto.Name
            };

            bool estaActualizado = _productoService.UpdateProducto(id, producto);

            if (estaActualizado) return Ok(new { message = "El producto fue actualziado correctamente.", estaActualizado} );

            return BadRequest();
        }
    }
}
