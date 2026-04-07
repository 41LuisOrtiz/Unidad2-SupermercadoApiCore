using Microsoft.AspNetCore.Mvc;
using SuperMercadoWebApplication.Entities.Supermercado;
using SuperMercadoWebApplication.Infraestructure.Interfases;

namespace SuperMercadoWebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly InterfaceClienteRepository _repo;

        public ClienteController(InterfaceClienteRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var lista = await _repo.ObtenerClientes();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _repo.ObtenerClientePorId(id);

            if (cliente == null)
                return NotFound("Cliente no encontrado");

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Cliente cliente)
        {
            await _repo.GuardarCliente(cliente);
            return Ok(cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Cliente cliente)
        {
            var existente = await _repo.ObtenerClientePorId(id);

            if (existente == null)
                return NotFound("Cliente no encontrado");

            await _repo.ActualizarCliente(cliente);
            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await _repo.ObtenerClientePorId(id);

            if (cliente == null)
                return NotFound("Cliente no encontrado");

            await _repo.EliminarCliente(id);
            return Ok("Cliente eliminado");
        }
    }
}