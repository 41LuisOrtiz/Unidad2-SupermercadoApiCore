using SuperMercadoWebApplication.Entities.Supermercado;

namespace SuperMercadoWebApplication.Features.Categorias.Interfaces
{
    public interface ICategoriaAppService
    {
        // Realiza el borrado lógico de la categoría (Activo = false)
        Task<bool> InactivarCategoriaAsync(int id);

        // Podrías agregar un método para obtener categorías con un filtro específico
        Task<IEnumerable<Categoria>> ListarCategoriasActivasAsync();
    }
}
