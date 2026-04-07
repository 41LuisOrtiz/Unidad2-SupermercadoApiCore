using SuperMercadoWebApplication.Entities.Supermercado;

namespace SuperMercadoWebApplication.Features.Productos.Interfaces
{
    public interface IProductoAppService
    {
        Task<bool> InactivarProductoAsync(int id);
        Task<bool> ActualizarStockAsync(int id, int nuevaCantidad);
    }
}