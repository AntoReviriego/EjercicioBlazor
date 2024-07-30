using Client.Services.Interface;
using SharedClasses;
using System.Net.Http.Json;

namespace Client.Services
{
    public class CategoriaService : ICategoria
    {
        private readonly HttpClient _http;
        public CategoriaService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<CategoriaDTO>> GetCategoria()
        {
            return await _http.GetFromJsonAsync<List<CategoriaDTO>>("Categoria/GetCategoria");
        }
    }
}
