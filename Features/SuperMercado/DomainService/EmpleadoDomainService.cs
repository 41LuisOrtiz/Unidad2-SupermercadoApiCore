using SuperMercadoWebApplication.Entities.Supermercado;
using SuperMercadoWebApplication.Features.SuperMercado.Dtos;
namespace SuperMercadoWebApplication.Features.SuperMercado.DomainService
{
    public class EmpleadoDomainService
    {
        public EmpleadoDomainService() { }
        public ApiResponse<Empleado> GuardarEmpleado(Empleado empleado)
        {
            ApiResponse<Empleado> apiResponse = new ApiResponse<Empleado>();
            if (string.IsNullOrEmpty(empleado.NombreEmpleado))
            {
                apiResponse.Success = false;
                apiResponse.Message = "El nombre del empleado es obligatorio.";
                return apiResponse;
            }
            if (string.IsNullOrEmpty(empleado.ApellidoEmpleado))
            {
                apiResponse.Success = false;
                apiResponse.Message = "El Apellido del empleado es obligatorio.";
                return apiResponse;
            }
            if (!string.IsNullOrEmpty(empleado.Cargo) && empleado.Cargo.Length > 50)
            {
                apiResponse.Success = false;
                apiResponse.Message = "Formato invalido";
                return apiResponse;
            }
            if (empleado.FechaContratacion > DateTime.Now)
            {
                apiResponse.Success = false;
                apiResponse.Message = "La fecha de contratación no puede ser futura.";
                return apiResponse;
            }
            
            // Si todas las validaciones pasan, el empleado es válido
            apiResponse.Success = true;
            apiResponse.Data = empleado;
            return apiResponse;
        }
    }
}
