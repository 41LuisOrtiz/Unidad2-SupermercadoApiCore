<<<<<<< HEAD
﻿using SuperMercadoWebApplication.Entities.Supermercado;
using SuperMercadoWebApplication.Features.SuperMercado.Dtos;
using SuperMercadoWebApplication.Features.SuperMercado.DomainService;
using SuperMercadoWebApplication.Features.SuperMercado.Interfaces;
using SuperMercadoWebApplication.Infraestructure.Interfases;
using SuperMercadoWebApplication.Infraestructure.Repositories;

namespace SuperMercadoWebApplication.Features.SuperMercado.AppService
{
    public class ProductoAppService : IProductoAppService
    {
        private readonly InterfaceProductoRepository productoRepository;
        private readonly InterfaceCategoriaRepository categoriasRepository;
        private readonly ProductoDomainService productosDomainService;
        public ProductoAppService(InterfaceProductoRepository productoRepository,
            ProductoDomainService productosDomainService,
            InterfaceCategoriaRepository categoriasRepository)
        {
            this.productoRepository = productoRepository;
            this.productosDomainService = productosDomainService;
            this.categoriasRepository = categoriasRepository;
        }

        public async Task ActualizarProducto(Producto producto)
        {
            await productoRepository.ActualizarProducto(producto);
        }

        public async Task<ApiResponse<Producto>> GuardarProducto(Producto producto)
        {
            ApiResponse<Producto> apiResponseResult =
                productosDomainService.GuardarProducto(producto);
            try
            {
                if (apiResponseResult.Success)
                {
                    await productoRepository.GuardarProducto(producto);
                }

                return apiResponseResult;
            }
            catch (Exception ex)
            {
                apiResponseResult.Success = false;
                apiResponseResult.Message = ex.Message;
                return apiResponseResult;
            }

        }

        public async Task EliminarProducto(int id)
        {
            await productoRepository.EliminarProducto(id);
        }

        public async Task<Producto> ObtenerProductoPorId(int id)
        {
            return await productoRepository.ObtenerProductoPorId(id);
        }

        public async Task<List<Producto>> ObtenerProductos()
        {
            return await productoRepository.ObtenerProductos();
        }

        public async Task<List<DatosProducto>> ObtenerProductosParaUsuario()
        {
            List<Categoria> categorias = await categoriasRepository.ObtenerCategorias();
            List<Producto> productos = await productoRepository.ObtenerProductos();

            var productosConCategoria =
                (
                    from p in productos
                    join c in categorias on p.IdCategoria equals c.CategoriaId
                    select new DatosProducto
                    {
                        Nombre = p.NombreProducto,
                        Precio = p.Precio,
                        Categoria = c.NombreCategoria,
                    }
                ).ToList();

            return productosConCategoria;
        }
=======
﻿namespace SuperMercadoWebApplication.Features.SuperMercado.AppService
{
    public class ProductoAppService
    {
>>>>>>> ce25912481bb92e7f930e96c7e3f7667d7705ed4
    }
}
