<<<<<<< HEAD
﻿using SuperMercadoWebApplication.Entities.Supermercado;

namespace SuperMercadoWebApplication.Features.SuperMercado.DomainService
{
    public class CategoriaDomainService
    {
        public CategoriaDomainService() { }
        public ApiResponse<Categoria> GuardarCategoria(Categoria categoria)
        {
            ApiResponse<Categoria> apiResponse = new ApiResponse<Categoria>();
            if (string.IsNullOrEmpty(categoria.NombreCategoria))
            {
                apiResponse.Success = false;
                apiResponse.Message = "El nombre de la categoría es obligatorio.";
                return apiResponse;
            }
            
            // Si todas las validaciones pasan, la categoría es válida
            apiResponse.Success = true;
            apiResponse.Data = categoria;
            return apiResponse;
        }
=======
﻿namespace SuperMercadoWebApplication.Features.SuperMercado.DomainService
{
    public class CategoriaDomainService
    {
>>>>>>> ce25912481bb92e7f930e96c7e3f7667d7705ed4
    }
}
