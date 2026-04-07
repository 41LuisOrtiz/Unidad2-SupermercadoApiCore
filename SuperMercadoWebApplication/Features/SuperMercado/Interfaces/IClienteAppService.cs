using SuperMercadoWebApplication.Entities.Supermercado;
namespace SuperMercadoWebApplication.Features.SuperMercado.Interfaces;

public interface IClienteAppService
{
    Task<List<Cliente>> ObtenerClientes();
    Task<Cliente> ObtenerClientePorId(int id);
    Task GuardarCliente(Cliente Cliente);
    Task ActualizarCliente(Cliente Cliente);
    Task EliminarCliente(int id);
}