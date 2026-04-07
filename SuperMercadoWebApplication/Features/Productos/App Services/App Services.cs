public class ProductoAppService : IProductoAppService
{
    private readonly IProductosRepository _repository;
    public ProductoAppService(IProductosRepository repository) => _repository = repository;

    public async Task<bool> InactivarProductoAsync(int id)
    {
        var producto = await _repository.GetByIdAsync(id);
        if (producto == null) return false;
        producto.Activo = false;
        _repository.Update(producto);
        await _repository.SaveChangesAsync();
        return true;
    }
}