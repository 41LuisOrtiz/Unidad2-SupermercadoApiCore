using Microsoft.AspNetCore.Mvc;
using SuperMercadoWebApplication.Entities.Supermercado;
using SuperMercadoWebApplication.Infraestructure.Interfases;

namespace SuperMercadoWebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ProductosController : ControllerBase
    {
        private readonly InterfaceProductoRepository _productoRepository;

        public ProductosController(InterfaceProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        // GET: api/productos
        [HttpGet]
        [ProducesResponseType(typeof(List<Producto>), 200)]
        public async Task<IActionResult> ObtenerProductos()
        {
            var productos = await _productoRepository.ObtenerProductos();
            return Ok(productos);
        }

        // GET: api/productos/5
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Producto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> ObtenerProductoPorId(int id)
        {
            var producto = await _productoRepository.ObtenerProductoPorId(id);

            if (producto.ProductoId == 0)
                return NotFound(new { mensaje = $"Producto con ID {id} no encontrado." });

            return Ok(producto);
        }

        // POST: api/productos
        [HttpPost]
        [ProducesResponseType(typeof(Producto), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GuardarProducto([FromBody] Producto producto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            producto.Activo = true;
            await _productoRepository.GuardarProducto(producto);
            return StatusCode(201, producto);
        }

        // PUT: api/productos
        [HttpPut]
        [ProducesResponseType(typeof(Producto), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> ActualizarProducto([FromBody] Producto producto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _productoRepository.ActualizarProducto(producto);
            return Ok(producto);
        }

        // DELETE: api/productos/5
        [HttpDelete("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> EliminarProducto(int id)
        {
            var producto = await _productoRepository.ObtenerProductoPorId(id);

            if (producto.ProductoId == 0)
                return NotFound(new { mensaje = $"Producto con ID {id} no encontrado." });

            await _productoRepository.EliminarProducto(id);
            return Ok(new { mensaje = "Producto inactivado correctamente." });
        }
    }
}