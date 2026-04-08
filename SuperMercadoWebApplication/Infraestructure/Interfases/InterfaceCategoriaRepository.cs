using SuperMercadoWebApplication.Entities.Supermercado;

namespace SuperMercadoWebApplication.Infraestructure.Interfases
{
    public interface InterfaceCategoriaRepository
    {
        Task<List<Categoria>> ObtenerCategorias();
        Task GuardarCategoria(Categoria categoria);
        Task ActualizarCategoria(Categoria categoria);
    }
}
