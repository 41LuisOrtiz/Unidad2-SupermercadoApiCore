using SuperMercadoWebApplication.Entities.Supermercado;
using SuperMercadoWebApplication.Infraestructure.Database;
using SuperMercadoWebApplication.Infraestructure.Interfases;
using Microsoft.EntityFrameworkCore;
namespace SuperMercadoWebApplication.Infraestructure.Repositories
{
    public class EmpleadoRepository: InterfaceEmpleadoRepository
    {
        private readonly SuperDbContext superDbContext;

        public EmpleadoRepository(SuperDbContext superDbContext)
        {
            this.superDbContext = superDbContext;
        }

        public async Task ActualizarEmpleado(Empleado empleado)
        {

            Empleado empleadoExistente =
                superDbContext.Empleados
                .FirstOrDefault(x => x.EmpleadoId == empleado.EmpleadoId)!;

            empleadoExistente.NombreEmpleado = empleado.NombreEmpleado;
            empleadoExistente.ApellidoEmpleado = empleado.ApellidoEmpleado;
            empleadoExistente.FechaContratacion = empleado.FechaContratacion;
            empleadoExistente.Cargo = empleado.Cargo;
            empleadoExistente.Activo = empleado.Activo;

            await superDbContext.SaveChangesAsync();
        }

        public async Task EliminarEmpleado(int id)
        {

            Empleado empleadoExistente =
                superDbContext.Empleados
                .FirstOrDefault(x => x.EmpleadoId == id)!;

            empleadoExistente.Activo = false;

            await superDbContext.SaveChangesAsync();
        }

        public async Task GuardarEmpleado(Empleado empleado)
        {
            superDbContext.Empleados.Add(empleado);
            await superDbContext.SaveChangesAsync();
        }

        public async Task<Empleado> ObtenerEmpleadoPorId(int id)
        {

            Empleado? empleado =
                await superDbContext.Empleados.FirstOrDefaultAsync(x => x.EmpleadoId == id);

            return empleado ?? new Empleado();
        }

        public async Task<List<Empleado>> ObtenerEmpleados()
        {
            return await superDbContext.Empleados.ToListAsync();
        }
    }
}
