public interface IEmpleadoAppService
{
    Task<IEnumerable<Empleado>> ListarPlanilla();
    Task Registrar(Empleado empleado);
    Task Inactivar(int id);
}