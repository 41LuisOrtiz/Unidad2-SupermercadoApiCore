using Microsoft.AspNetCore.Mvc;
using SuperMercadoWebApplication.Entities.Supermercado;
using SuperMercadoWebApplication.Infraestructure.Interfases;

namespace SuperMercadoWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly InterfaceCategoriaRepository _categoriaRepository;

        // Constructor para inyectar el repositorio
        public CategoriaController(InterfaceCategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        // GET: api/Categoria
        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> ObtenerCategorias()
        {
            try
            {
                var categorias = await _categoriaRepository.ObtenerCategorias();
                return Ok(categorias);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // POST: api/Categoria
        [HttpPost]
        public async Task<ActionResult> GuardarCategoria([FromBody] Categoria categoria)
        {
            if (categoria == null)
                return BadRequest("La categoría es nula.");

            try
            {
                await _categoriaRepository.GuardarCategoria(categoria);
                // No usamos Id aquí porque tu clase puede no tenerlo
                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al guardar la categoría: {ex.Message}");
            }
        }

        // PUT: api/Categoria/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarCategoria(int id, [FromBody] Categoria categoria)
        {
            // Cambia CategoriaId por el nombre exacto de tu propiedad clave primaria
            if (categoria == null || id != categoria.CategoriaId)
                return BadRequest("Datos inválidos.");

            try
            {
                await _categoriaRepository.ActualizarCategoria(categoria);
                return NoContent(); // 204: Actualización exitosa
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar la categoría: {ex.Message}");
            }
        }
    }
}