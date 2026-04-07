public class ProductoDomainService
{
    public bool ValidarStockParaVenta(int stockActual, int cantidad)
    {
        return stockActual >= cantidad;
    }
}