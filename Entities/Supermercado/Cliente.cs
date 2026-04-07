namespace SuperMercadoWebApplication.Entities.Supermercado
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string NombreCliente { get; set; }
        public string ApellidoCliente { get; set; }
        public string RTN { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public bool Activo { get; set; }
    }
}
