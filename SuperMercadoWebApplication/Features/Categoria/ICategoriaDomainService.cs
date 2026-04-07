namespace SuperMercadoWebApplication.Features.Categorias.Interfaces
{
    public interface ICategoriaDomainService
    {
        // Valida si el nombre de la categoría cumple con los estándares (longitud, caracteres, etc.)
        bool ValidarNombreCategoria(string nombre);

        // Define si una categoría es considerada "Prioritaria" según su descripción
        bool EsCategoriaEspecial(string descripcion);
    }
}