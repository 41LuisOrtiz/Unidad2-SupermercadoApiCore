
using SuperMercadoWebApplication.Entities.Supermercado;
using SuperMercadoWebApplication.Infraestructure.Database;
using SuperMercadoWebApplication.Infraestructure.Interfases;
using Microsoft.EntityFrameworkCore;
namespace SuperMercadoWebApplication.Infraestructure.Repositories
{
    public class ProductoRepository : InterfaceProductoRepository
    {
        private readonly SuperDbContext superDbContext;

        public ProductoRepository(SuperDbContext superDbContext)
        {
            this.superDbContext = superDbContext;
        }

        public async Task ActualizarProducto(Producto producto)
        {
            
            Producto productoExistente =
                superDbContext.Productos
                .FirstOrDefault(x => x.ProductoId == producto.ProductoId)!;

            productoExistente.NombreProducto = producto.NombreProducto;
            productoExistente.Precio = producto.Precio;
            productoExistente.Stock = producto.Stock;
            productoExistente.IdCategoria = producto.IdCategoria;
            productoExistente.Activo = producto.Activo;

            await superDbContext.SaveChangesAsync();
        }

        public async Task EliminarProducto(int id)
        {
            
            Producto productoExistente =
                superDbContext.Productos
                .FirstOrDefault(x => x.ProductoId == id)!;

            productoExistente.Activo = false;

            await superDbContext.SaveChangesAsync();
        }

        public async Task GuardarProducto(Producto producto)
        {
            superDbContext.Productos.Add(producto);
            await superDbContext.SaveChangesAsync();
        }

        public async Task<Producto> ObtenerProductoPorId(int id)
        {

            Producto? producto =
                await superDbContext.Productos.FirstOrDefaultAsync(x => x.ProductoId == id);

            return producto ?? new Producto();
        }

        public async Task<List<Producto>> ObtenerProductos()
        {
            return await superDbContext.Productos.ToListAsync();
        }
    }
}
