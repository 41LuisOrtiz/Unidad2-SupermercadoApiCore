namespace SuperMercadoWebApplication.Entities.Supermercado
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }
        public int IdCategoria { get; set; }
        public bool Activo { get; set; }

    }
}
