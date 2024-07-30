using SharedClasses;

namespace Client.Services.Interface
{
    public interface IMarca
    {
        Task<List<MarcaDTO>> GetMarcas();
    }
}
