namespace SuperMercadoWebApplication.Features.Empleados.Interfaces
{
    public interface IEmpleadoDomainService
    {
        // Calcula la antigüedad del empleado basada en su fecha de contratación
        int CalcularAniosAntiguedad(DateTime fechaContratacion);
    }
}