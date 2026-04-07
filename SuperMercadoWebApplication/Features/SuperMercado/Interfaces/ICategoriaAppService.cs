using SuperMercadoWebApplication.Entities.Supermercado;
public interface ICategoriaAppService
{
    Task<List<Categoria>> ObtenerCategorias();
    Task GuardarCategoria(Categoria categoria);
    Task ActualizarCategoria(Categoria categoria);
}