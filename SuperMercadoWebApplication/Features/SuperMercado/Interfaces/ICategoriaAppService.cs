using SuperMercadoWebApplication.Entities.Supermercado;
namespace SuperMercadoWebApplication.Features.SuperMercado.Interfaces;

public interface ICategoriaAppService
{
    Task<List<Categoria>> ObtenerCategorias();
    Task GuardarCategoria(Categoria categoria);
    Task ActualizarCategoria(Categoria categoria);
}