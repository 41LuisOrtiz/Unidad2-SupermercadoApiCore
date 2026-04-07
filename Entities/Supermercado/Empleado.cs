namespace SuperMercadoWebApplication.Entities.Supermercado
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }
        public string NombreEmpleado { get; set; }
        public string ApellidoEmpleado { get; set; }
        public string Cargo { get; set; }
        public DateTime FechaContratacion { get; set; }
        public bool Activo { get; set; }
    }
}
