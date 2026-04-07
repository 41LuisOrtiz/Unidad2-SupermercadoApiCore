public class ProductoDto
{
    public int ProductoId { get; set; }
    public string NombreProducto { get; set; } = null!;
    public double Precio { get; set; }
    public int Stock { get; set; }
    public int IdCategoria { get; set; }
}