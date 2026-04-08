using SuperMercadoWebApplication.Entities.Supermercado;
namespace SuperMercadoWebApplication.Infraestructure.Interfases
{
    public interface InterfaceEmpleadoRepository
    {
        Task<List<Empleado>> ObtenerEmpleados();
        Task<Empleado> ObtenerEmpleadoPorId(int id);
        Task GuardarEmpleado(Empleado Empleado);
        Task ActualizarEmpleado(Empleado Empleado);
        Task EliminarEmpleado(int id);
    }
}
