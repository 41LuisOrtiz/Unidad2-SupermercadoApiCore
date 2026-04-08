<<<<<<< HEAD
﻿using SuperMercadoWebApplication.Entities.Supermercado;
using SuperMercadoWebApplication.Features.SuperMercado.DomainService;
using SuperMercadoWebApplication.Features.SuperMercado.Interfaces;
using SuperMercadoWebApplication.Infraestructure.Interfases;

namespace SuperMercadoWebApplication.Features.SuperMercado.AppService
{
    public class EmpleadoAppService : IEmpleadoAppService
    {
        public readonly InterfaceEmpleadoRepository empleadoRepository;
        public readonly EmpleadoDomainService empleadoDomainService;

        public EmpleadoAppService(InterfaceEmpleadoRepository empleadoRepository,
            EmpleadoDomainService empleadoDomainService)
        {
            this.empleadoRepository = empleadoRepository;
            this.empleadoDomainService = empleadoDomainService;
        }
        public async Task ActualizarEmpleado(Empleado Empleado)
        {
            await empleadoRepository.ActualizarEmpleado(Empleado);
        }

        public async Task EliminarEmpleado(int id)
        {
            await empleadoRepository.EliminarEmpleado(id);
        }

        public async Task<ApiResponse<Empleado>> GuardarEmpleado(Empleado empleado)
        {
            ApiResponse<Empleado> apiResponseResult =
                empleadoDomainService.GuardarEmpleado(empleado);
            try
            {
                if (apiResponseResult.Success)
                {
                    await empleadoRepository.GuardarEmpleado(empleado);
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

        public async Task<Empleado> ObtenerEmpleadoPorId(int id)
        {
            return await empleadoRepository.ObtenerEmpleadoPorId(id);
        }

        public async Task<List<Empleado>> ObtenerEmpleados()
        {
            return await empleadoRepository.ObtenerEmpleados();
        }
=======
﻿namespace SuperMercadoWebApplication.Features.SuperMercado.AppService
{
    public class EmpleadoAppService
    {
>>>>>>> ce25912481bb92e7f930e96c7e3f7667d7705ed4
    }
}
