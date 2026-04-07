using Microsoft.AspNetCore.Mvc;
using SuperMercadoWebApplication.Entities.Supermercado;
using SuperMercadoWebApplication.Infraestructure.Interfases;

namespace SuperMercadoWebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly InterfaceProductoRepository _repo;

        public ProductoController(InterfaceProductoRepository repo)
        {
            _repo = repo;
        }

        // GET: api/producto
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var lista = await _repo.ObtenerProductos();
            return Ok(lista);
        }

        // GET: api/producto/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var producto = await _repo.ObtenerProductoPorId(id);

            if (producto == null)
                return NotFound("Producto no encontrado");

            return Ok(producto);
        }

        // POST: api/producto
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Producto producto)
        {
            await _repo.GuardarProducto(producto);
            return Ok(producto);
        }

        // PUT: api/producto/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Producto producto)
        {
            var existente = await _repo.ObtenerProductoPorId(id);

            if (existente == null)
                return NotFound("Producto no encontrado");

            await _repo.ActualizarProducto(producto);
            return Ok(producto);
        }

        // DELETE: api/producto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var producto = await _repo.ObtenerProductoPorId(id);

            if (producto == null)
                return NotFound("Producto no encontrado");

            await _repo.EliminarProducto(id);
            return Ok("Producto eliminado");
        }
    }
}
