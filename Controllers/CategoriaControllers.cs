using Microsoft.AspNetCore.Mvc;
using SuperMercadoWebApplication.Entities.Supermercado;
using SuperMercadoWebApplication.Features.SuperMercado.Interfaces;

namespace SuperMercadoWebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaAppService _categoriaAppService;

        public CategoriaController(ICategoriaAppService categoriaAppService)
        {
            _categoriaAppService = categoriaAppService;
        }

        // GET: api/categoria/getcategorias
        [HttpGet]
        [Route("getcategorias")]
        public async Task<IActionResult> ObtenerCategorias()
        {
            var categorias = await _categoriaAppService.ObtenerCategorias();
            return Ok(categorias);
        }

        // POST: api/categoria/guardarCategoria
        [HttpPost]
        [Route("guardarCategoria")]
        public async Task<IActionResult> GuardarCategoria([FromBody] Categoria categoria)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            categoria.Activo = true;
            await _categoriaAppService.GuardarCategoria(categoria);
            return StatusCode(201, categoria);
        }

        // PUT: api/categoria/actualizarCategoria
        [HttpPut]
        [Route("actualizarCategoria")]
        public async Task<IActionResult> ActualizarCategoria([FromBody] Categoria categoria)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _categoriaAppService.ActualizarCategoria(categoria);
            return Ok(categoria);
        }
    }
}
