using Microsoft.AspNetCore.Mvc;
using SuperMercadoWebApplication.Entities.Supermercado;
using SuperMercadoWebApplication.Infraestructure.Interfases;

namespace SuperMercadoWebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class EmpleadosController : ControllerBase
    {
        private readonly InterfaceEmpleadoRepository _empleadoRepository;

        public EmpleadosController(InterfaceEmpleadoRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }

        // GET: api/empleados
        [HttpGet]
        [ProducesResponseType(typeof(List<Empleado>), 200)]
        public async Task<IActionResult> ObtenerEmpleados()
        {
            var empleados = await _empleadoRepository.ObtenerEmpleados();
            return Ok(empleados);
        }

        // GET: api/empleados/5
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Empleado), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> ObtenerEmpleadoPorId(int id)
        {
            var empleado = await _empleadoRepository.ObtenerEmpleadoPorId(id);

            if (empleado.EmpleadoId == 0)
                return NotFound(new { mensaje = $"Empleado con ID {id} no encontrado." });

            return Ok(empleado);
        }

        // POST: api/empleados
        [HttpPost]
        [ProducesResponseType(typeof(Empleado), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GuardarEmpleado([FromBody] Empleado empleado)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            empleado.Activo = true;
            await _empleadoRepository.GuardarEmpleado(empleado);
            return StatusCode(201, empleado);
        }

        // PUT: api/empleados
        [HttpPut]
        [ProducesResponseType(typeof(Empleado), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> ActualizarEmpleado([FromBody] Empleado empleado)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _empleadoRepository.ActualizarEmpleado(empleado);
            return Ok(empleado);
        }

        // DELETE: api/empleados/5
        [HttpDelete("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> EliminarEmpleado(int id)
        {
            var empleado = await _empleadoRepository.ObtenerEmpleadoPorId(id);

            if (empleado.EmpleadoId == 0)
                return NotFound(new { mensaje = $"Empleado con ID {id} no encontrado." });

            await _empleadoRepository.EliminarEmpleado(id);
            return Ok(new { mensaje = "Empleado inactivado correctamente." });
        }
    }
}