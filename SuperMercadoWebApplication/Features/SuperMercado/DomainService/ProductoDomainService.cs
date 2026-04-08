<<<<<<< HEAD
﻿using SuperMercadoWebApplication.Entities.Supermercado;
using SuperMercadoWebApplication;
using Microsoft.IdentityModel.Tokens;
namespace SuperMercadoWebApplication.Features.SuperMercado.DomainService
{
    public class ProductoDomainService
    {
        public ProductoDomainService() { }
        public ApiResponse<Producto> GuardarProducto(Producto producto)
        {
            ApiResponse<Producto> apiResponse = new ApiResponse<Producto>();
            if (producto.NombreProducto == null)
            {   
                apiResponse.Message = "|Error| El nombre del producto no puede ser nulo.";
                apiResponse.Success = false;
            }
            if (producto.Precio <= 0)
            {
                apiResponse.Message = "|Error| El precio del producto debe ser mayor a cero.";
                apiResponse.Success = false;
            }
            if (producto.Stock < 0)
            {
                apiResponse.Message = "|Error| El stock del producto no puede ser negativo.";
                apiResponse.Success = false;
            }
            if (producto.IdCategoria < 0 || producto.IdCategoria.ToString().IsNullOrEmpty())
            {
                apiResponse.Message = "|Error| El ID de la categoría debe ser mayor a cero.";
                apiResponse.Success = false;
            }
            
            return apiResponse;
        }
=======
﻿namespace SuperMercadoWebApplication.Features.SuperMercado.DomainService
{
    public class ProductoDomainService
    {
>>>>>>> ce25912481bb92e7f930e96c7e3f7667d7705ed4
    }
}
