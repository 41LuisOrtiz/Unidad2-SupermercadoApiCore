<<<<<<< HEAD
﻿using SuperMercadoWebApplication.Entities.Supermercado;
using SuperMercadoWebApplication.Features.SuperMercado.DomainService;
using SuperMercadoWebApplication.Features.SuperMercado.Interfaces;
using SuperMercadoWebApplication.Infraestructure.Interfases;
using SuperMercadoWebApplication.Infraestructure.Repositories;


namespace SuperMercadoWebApplication.Features.SuperMercado.AppService
{
    public class CategoriaAppService : ICategoriaAppService
    {
        private readonly InterfaceCategoriaRepository categoriasRepository;
        public CategoriaAppService(InterfaceCategoriaRepository categoriasRepository)
        {
            this.categoriasRepository = categoriasRepository;
        }
        public async Task ActualizarCategoria(Categoria categoria)
        {
            await categoriasRepository.ActualizarCategoria(categoria);
        }

        public async Task GuardarCategoria(Categoria categoria)
        {
            await categoriasRepository.GuardarCategoria(categoria);
        }

        public async Task<List<Categoria>> ObtenerCategorias()
        {
            return await categoriasRepository.ObtenerCategorias();
        }

=======
﻿namespace SuperMercadoWebApplication.Features.SuperMercado.AppService
{
    public class CategoriaAppService
    {
>>>>>>> ce25912481bb92e7f930e96c7e3f7667d7705ed4
    }
}
