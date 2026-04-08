using SuperMercadoWebApplication.Entities.Supermercado;
namespace SuperMercadoWebApplication.Infraestructure.Interfases
{
    public interface InterfaceClienteRepository
    {
        Task<List<Cliente>> ObtenerClientes();
        Task<Cliente> ObtenerClientePorId(int id);
        Task GuardarCliente(Cliente Cliente);
        Task ActualizarCliente(Cliente Cliente);
        Task EliminarCliente(int id);
    }
}
