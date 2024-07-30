using Client.Services.Interface;
using SharedClasses;
using System.Net.Http.Json;

namespace Client.Services
{
    public class MarcaService : IMarca
    {
        private readonly HttpClient _http;
        public MarcaService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<MarcaDTO>> GetMarcas()
        {
            return await _http.GetFromJsonAsync<List<MarcaDTO>>("Marca/GetMarcas");
        }
    }
}
