using SharedClasses;

namespace Client.Services.Interface
{
    public interface ICategoria
    {
        Task<List<CategoriaDTO>> GetCategoria();
    }
}
