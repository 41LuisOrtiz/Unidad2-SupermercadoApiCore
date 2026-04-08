using SuperMercadoWebApplication.Entities.Supermercado;
using SuperMercadoWebApplication.Infraestructure.Database;
using SuperMercadoWebApplication.Infraestructure.Interfases;
using Microsoft.EntityFrameworkCore;
namespace SuperMercadoWebApplication.Infraestructure.Repositories
{
    public class CategoriaRepository : InterfaceCategoriaRepository
    {
        private readonly SuperDbContext superDbContext;

        public CategoriaRepository(SuperDbContext superDbContext)
        {
            this.superDbContext = superDbContext;
        }

        public async Task ActualizarCategoria(Categoria categoria)
        {
            Categoria? categoriaExistente =
                await superDbContext.Categorias
                .FirstOrDefaultAsync(x => x.CategoriaId == categoria.CategoriaId);

            if (categoriaExistente != null)
            {
                categoriaExistente.NombreCategoria = categoria.NombreCategoria;
                categoriaExistente.Activo = categoria.Activo;
                await superDbContext.SaveChangesAsync();
            }
        }

        public async Task GuardarCategoria(Categoria categoria)
        {
            await superDbContext.Categorias.AddAsync(categoria);
            await superDbContext.SaveChangesAsync();
        }

        public async Task<List<Categoria>> ObtenerCategorias() => await superDbContext.Categorias.ToListAsync();
    }

}