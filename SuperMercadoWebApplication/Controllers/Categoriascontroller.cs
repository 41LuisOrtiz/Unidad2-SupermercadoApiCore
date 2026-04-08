using Microsoft.AspNetCore.Mvc;
using SuperMercadoWebApplication.Entities.Supermercado;
using SuperMercadoWebApplication.Infraestructure.Interfases;

namespace SuperMercadoWebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CategoriasController : ControllerBase
    {
        private readonly InterfaceCategoriaRepository _categoriaRepository;

        public CategoriasController(InterfaceCategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        // GET: api/categorias
        [HttpGet]
        [ProducesResponseType(typeof(List<Categoria>), 200)]
        public async Task<IActionResult> ObtenerCategorias()
        {
            var categorias = await _categoriaRepository.ObtenerCategorias();
            return Ok(categorias);
        }

        // POST: api/categorias
        [HttpPost]
        [ProducesResponseType(typeof(Categoria), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GuardarCategoria([FromBody] Categoria categoria)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            categoria.Activo = true;
            await _categoriaRepository.GuardarCategoria(categoria);
            return StatusCode(201, categoria);
        }

        // PUT: api/categorias
        [HttpPut]
        [ProducesResponseType(typeof(Categoria), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> ActualizarCategoria([FromBody] Categoria categoria)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _categoriaRepository.ActualizarCategoria(categoria);
            return Ok(categoria);
        }
    }
}