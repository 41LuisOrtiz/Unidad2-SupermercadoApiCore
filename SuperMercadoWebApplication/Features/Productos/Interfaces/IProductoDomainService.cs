namespace SuperMercadoWebApplication.Features.Productos.Interfaces
{
    public interface IProductoDomainService
    {
        // Valida si existe cantidad suficiente para procesar un movimiento
        bool ValidarStockDisponible(int stockActual, int cantidadSolicitada);
        // Calcula el precio final aplicando reglas de negocio específicas
        double CalcularPrecioVenta(double precioBase, int stock);
    }
}