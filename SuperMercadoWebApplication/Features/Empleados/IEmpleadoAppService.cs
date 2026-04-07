namespace SuperMercadoWebApplication.Features.Empleados.Interfaces
{
    public interface IEmpleadoAppService
    {
        Task<bool> InactivarEmpleadoAsync(int id);
    }
}