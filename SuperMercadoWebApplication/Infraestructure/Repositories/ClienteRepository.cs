using SuperMercadoWebApplication.Entities.Supermercado;
using SuperMercadoWebApplication.Infraestructure.Database;
using SuperMercadoWebApplication.Infraestructure.Interfases;
using Microsoft.EntityFrameworkCore;
namespace SuperMercadoWebApplication.Infraestructure.Repositories
{
    public class ClienteRepository: InterfaceClienteRepository
    {
        private readonly SuperDbContext superDbContext;

        public ClienteRepository(SuperDbContext superDbContext)
        {
            this.superDbContext = superDbContext;
        }

        public async Task ActualizarCliente(Cliente cliente)
        {

            Cliente clienteExistente =
                superDbContext.Clientes
                .FirstOrDefault(x => x.ClienteId == cliente.ClienteId)!;

            clienteExistente.NombreCliente = cliente.NombreCliente;
            clienteExistente.ApellidoCliente = cliente.ApellidoCliente;
            clienteExistente.Telefono = cliente.Telefono;
            clienteExistente.CorreoElectronico = cliente.CorreoElectronico;
            clienteExistente.RTN = cliente.RTN;
            clienteExistente.Activo = cliente.Activo;

            await superDbContext.SaveChangesAsync();
        }

        public async Task EliminarCliente(int id)
        {

            Cliente clienteExistente =
                superDbContext.Clientes
                .FirstOrDefault(x => x.ClienteId == id)!;

            clienteExistente.Activo = false;

            await superDbContext.SaveChangesAsync();
        }

        public async Task GuardarCliente(Cliente cliente)
        {
            superDbContext.Clientes.Add(cliente);
            await superDbContext.SaveChangesAsync();
        }

        public async Task<Cliente> ObtenerClientePorId(int id)
        {

            Cliente? cliente =
                await superDbContext.Clientes.FirstOrDefaultAsync(x => x.ClienteId == id);

            return cliente ?? new Cliente();
        }

        public async Task<List<Cliente>> ObtenerClientes()
        {
            return await superDbContext.Clientes.ToListAsync();
        }
    }
}
