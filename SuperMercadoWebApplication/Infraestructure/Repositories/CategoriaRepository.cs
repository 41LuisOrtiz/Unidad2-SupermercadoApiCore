using SuperMercadoWebApplication.Entities.Supermercado;
using SuperMercadoWebApplication.Infraestructure.Database;
using SuperMercadoWebApplication.Infraestructure.Interfases;
using Microsoft.EntityFrameworkCore;
namespace SuperMercadoWebApplication.Infraestructure.Repositories
{
<<<<<<< HEAD
    public class CategoriaRepository : InterfaceCategoriaRepository
    {
        private readonly SuperDbContext superDbContext;

        public CategoriaRepository(SuperDbContext superDbContext)
=======
    public class CategoriasRepository : InterfaceCategoriaRepository
    {
        private readonly SuperDbContext superDbContext;

        public CategoriasRepository(SuperDbContext superDbContext)
>>>>>>> ce25912481bb92e7f930e96c7e3f7667d7705ed4
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

<<<<<<< HEAD
        public async Task<List<Categoria>> ObtenerCategorias() => await superDbContext.Categorias.ToListAsync();
    }

}
=======
        public async Task<List<Categoria>> ObtenerCategorias()
        {
            return await superDbContext.Categorias.ToListAsync();
        }
    }
>>>>>>> ce25912481bb92e7f930e96c7e3f7667d7705ed4
