namespace SuperMercadoWebApplication.Features.Clientes.Interfaces
{
    public interface IClienteAppService
    {
        Task<bool> InactivarClienteAsync(int id);
        Task<bool> EsClientePremiumAsync(int id);
    }
}