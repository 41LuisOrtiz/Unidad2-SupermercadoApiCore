using SuperMercadoWebApplication.Entities.Supermercado;
namespace SuperMercadoWebApplication.Infraestructure.Interfases

{
    public interface InterfaceProductoRepository
    {
        Task<List<Producto>> ObtenerProductos();
        Task<Producto> ObtenerProductoPorId(int id);
        Task GuardarProducto(Producto Producto);
        Task ActualizarProducto(Producto Producto);
        Task EliminarProducto(int id);
    }
}
