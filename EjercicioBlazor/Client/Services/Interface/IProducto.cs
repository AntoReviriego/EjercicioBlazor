using SharedClasses;

namespace Client.Services.Interface
{
    public interface IProducto
    {
        Task<List<ProductosDTO>> GetProdutos();
        Task<ProductoDTO> GetProductoById(long id);
        Task<bool> PostProducto(ProductoDTO producto);
        Task<bool> PutProducto(ProductoDTO producto);
        Task<bool> DeleteProducto(ProductosDTO producto);
    }
}
