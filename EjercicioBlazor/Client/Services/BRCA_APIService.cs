using SharedClasses;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using static System.Net.WebRequestMethods;
namespace Client.Services
{
    public class BRCA_APIService
    {
        private readonly HttpClient _http;
        public BRCA_APIService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<APIClass>> GetAPI(string urlApi)
        {
            return await _http.GetFromJsonAsync<List<APIClass>>($"API/GetAPI/{urlApi}");
        }
    }
}
