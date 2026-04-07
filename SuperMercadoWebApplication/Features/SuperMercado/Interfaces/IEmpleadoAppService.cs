using SuperMercadoWebApplication.Entities.Supermercado;
namespace SuperMercadoWebApplication.Features.SuperMercado.Interfaces;

public interface IEmpleadoAppService
{
    Task<List<Empleado>> ObtenerEmpleados();
    Task<Empleado> ObtenerEmpleadoPorId(int id);
    Task GuardarEmpleado(Empleado Empleado);
    Task ActualizarEmpleado(Empleado Empleado);
    Task EliminarEmpleado(int id);
}