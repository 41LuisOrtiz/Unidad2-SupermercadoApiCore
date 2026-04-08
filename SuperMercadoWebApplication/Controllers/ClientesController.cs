using Microsoft.AspNetCore.Mvc;
using SuperMercadoWebApplication.Entities.Supermercado;
using SuperMercadoWebApplication.Infraestructure.Interfases;

namespace SuperMercadoWebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly InterfaceClienteRepository _clienteRepository;

        public ClientesController(InterfaceClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        // GET: api/clientes
        [HttpGet]
        [Route("ObtenerClientes ")]
        public async Task<IActionResult> ObtenerClientes()
        {
            var clientes = await _clienteRepository.ObtenerClientes();
            return Ok(clientes);
        }

        // GET: api/clientes/5
        [HttpGet("{id:int}")]
        [Route("ObtenerClientePorId")]
        public async Task<IActionResult> ObtenerClientePorId(int id)
        {
            var cliente = await _clienteRepository.ObtenerClientePorId(id);

            if (cliente.ClienteId == 0)
                return NotFound(new { mensaje = $"Cliente con ID {id} no encontrado." });

            return Ok(cliente);
        }

        // POST: api/clientes
        [HttpPost]
        [Route("GuardarCliente")]
        public async Task<IActionResult> GuardarCliente([FromBody] Cliente cliente)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            cliente.Activo = true;
            await _clienteRepository.GuardarCliente(cliente);
            return StatusCode(201, cliente);
        }

        // PUT: api/clientes
        [HttpPut][Route("Actualizar")]
        public async Task<IActionResult> ActualizarCliente([FromBody] Cliente cliente)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _clienteRepository.ActualizarCliente(cliente);
            return Ok(cliente);
        }

        // DELETE: api/clientes/5
        [HttpDelete("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> EliminarCliente(int id)
        {
            var cliente = await _clienteRepository.ObtenerClientePorId(id);

            if (cliente.ClienteId == 0)
                return NotFound(new { mensaje = $"Cliente con ID {id} no encontrado." });

            await _clienteRepository.EliminarCliente(id);
            return Ok(new { mensaje = "Cliente inactivado correctamente." });
        }
    }
}
