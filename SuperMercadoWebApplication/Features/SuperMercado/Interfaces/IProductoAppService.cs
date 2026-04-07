using SuperMercadoWebApplication.Entities.Supermercado;
namespace SuperMercadoWebApplication.Features.SuperMercado.Interfaces;

public interface IProductoAppService
{
    Task<List<Producto>> ObtenerProductos();
    Task<Producto> ObtenerProductoPorId(int id);
    Task GuardarProducto(Producto Producto);
    Task ActualizarProducto(Producto Producto);
    Task EliminarProducto(int id);
}