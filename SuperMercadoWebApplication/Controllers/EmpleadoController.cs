using Microsoft.AspNetCore.Mvc;
using SuperMercadoWebApplication.Entities.Supermercado;
using SuperMercadoWebApplication.Infraestructure.Interfases;

namespace SuperMercadoWebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadoController : ControllerBase
    {
        private readonly InterfaceEmpleadoRepository _repo;

        public EmpleadoController(InterfaceEmpleadoRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var lista = await _repo.ObtenerEmpleados();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var empleado = await _repo.ObtenerEmpleadoPorId(id);

            if (empleado == null)
                return NotFound("Empleado no encontrado");

            return Ok(empleado);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Empleado empleado)
        {
            await _repo.GuardarEmpleado(empleado);
            return Ok(empleado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Empleado empleado)
        {
            var existente = await _repo.ObtenerEmpleadoPorId(id);

            if (existente == null)
                return NotFound("Empleado no encontrado");

            await _repo.ActualizarEmpleado(empleado);
            return Ok(empleado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var empleado = await _repo.ObtenerEmpleadoPorId(id);

            if (empleado == null)
                return NotFound("Empleado no encontrado");

            await _repo.EliminarEmpleado(id);
            return Ok("Empleado eliminado");
        }
    }
}