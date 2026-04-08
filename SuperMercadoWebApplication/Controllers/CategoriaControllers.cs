using Microsoft.AspNetCore.Mvc;
using SuperMercadoWebApplication.Entities.Supermercado;
using SuperMercadoWebApplication.Infraestructure.Interfases;

namespace SuperMercadoWebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly InterfaceCategoriaRepository _categoriaRepository;

        public CategoriaController(InterfaceCategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        // GET: api/categorias
        [HttpGet]
        [Route("getCategorias")]
        public async Task<IActionResult> ObtenerCategorias()
        {
            List<Categoria> categorias = await _categoriaRepository.ObtenerCategorias();
            return Ok(categorias);
        }

        // POST: api/categorias
        [HttpPost]
        [Route ("guardarCategoria")]
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
        [Route("actualizarCategoria")]
        public async Task<IActionResult> ActualizarCategoria([FromBody] Categoria categoria)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _categoriaRepository.ActualizarCategoria(categoria);
            return Ok(categoria);
        }
    }
}
