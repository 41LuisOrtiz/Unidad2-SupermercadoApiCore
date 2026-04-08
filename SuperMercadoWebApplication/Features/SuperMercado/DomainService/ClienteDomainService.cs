<<<<<<< HEAD
﻿using SuperMercadoWebApplication.Entities.Supermercado;

namespace SuperMercadoWebApplication.Features.SuperMercado.DomainService
{
    public class ClienteDomainService
    {
        public ClienteDomainService() { }
        public ApiResponse<Cliente> GuardarCliente(Cliente cliente)
        {
            ApiResponse<Cliente> apiResponse = new ApiResponse<Cliente>();
            if (string.IsNullOrEmpty(cliente.NombreCliente))
            {
                apiResponse.Success = false;
                apiResponse.Message = "El nombre del cliente es obligatorio.";
                return apiResponse;
            }
            if (string.IsNullOrEmpty(cliente.CorreoElectronico))
            {
                apiResponse.Success = false;
                apiResponse.Message = "El email del cliente es obligatorio.";
                return apiResponse;
            }
            if (cliente.RTN == null || cliente.RTN.Length != 14)
            {
                apiResponse.Success = false;
                apiResponse.Message = "El RTN del cliente debe tener exactamente 14 caracteres.";
                return apiResponse;
            }
            // Validar que el cliente tenga al menos un teléfono
            if (cliente.Telefono == null)
            {
                apiResponse.Success = false;
                apiResponse.Message = "El cliente debe tener al menos un teléfono.";
                return apiResponse;
            }
            
            // Si todas las validaciones pasan, el cliente es válido
            apiResponse.Success = true;
            apiResponse.Data = cliente;
            return apiResponse;
        }
=======
﻿namespace SuperMercadoWebApplication.Features.SuperMercado.DomainService
{
    public class ClienteDomainService
    {
>>>>>>> ce25912481bb92e7f930e96c7e3f7667d7705ed4
    }
}
