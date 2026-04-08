<<<<<<< HEAD
﻿using SuperMercadoWebApplication.Entities.Supermercado;
using SuperMercadoWebApplication.Features.SuperMercado.Dtos;
using SuperMercadoWebApplication.Features.SuperMercado.DomainService;
using SuperMercadoWebApplication.Features.SuperMercado.Interfaces;
using SuperMercadoWebApplication.Infraestructure.Interfases;
using SuperMercadoWebApplication.Infraestructure.Repositories;

namespace SuperMercadoWebApplication.Features.SuperMercado.AppService
{
    public class ClienteAppService : IClienteAppService

    {
        public readonly InterfaceClienteRepository clienteRepository;
        public readonly ClienteDomainService clienteDomainService;

        public ClienteAppService(InterfaceClienteRepository clienteRepository,
            ClienteDomainService clienteDomainService)
        {
            this.clienteRepository = clienteRepository;
            this.clienteDomainService = clienteDomainService;
        }
        public async Task ActualizarCliente(Cliente Cliente)
        {
            await clienteRepository.ActualizarCliente(Cliente);
        }

        public async Task EliminarCliente(int id)
        {
            await clienteRepository.EliminarCliente(id);
        }

        public async Task<ApiResponse<Cliente>> GuardarCliente(Cliente cliente)
        {
            ApiResponse<Cliente> apiResponseResult =
                clienteDomainService.GuardarCliente(cliente);
            try
            {
                if (apiResponseResult.Success)
                {
                    await clienteRepository.GuardarCliente(cliente);
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

        public async Task<Cliente> ObtenerClientePorId(int id)
        {
            return await clienteRepository.ObtenerClientePorId(id);
        }

        public async Task<List<Cliente>> ObtenerClientes()
        {
            return await clienteRepository.ObtenerClientes();
        }
=======
﻿namespace SuperMercadoWebApplication.Features.SuperMercado.AppService
{
    public class ClienteAppService
    {
>>>>>>> ce25912481bb92e7f930e96c7e3f7667d7705ed4
    }
}
