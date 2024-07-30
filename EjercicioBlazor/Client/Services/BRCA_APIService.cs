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

        public async Task<List<APIClass>> GetIndicadoresEconomicosAsync()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "https://api.estadisticasbcra.com/base");
                string token = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE3NTM4NDQ0NDYsInR5cGUiOiJleHRlcm5hbCIsInVzZXIiOiJhbnRvcmV2aXJpZWdvQGdtYWlsLmNvbSJ9.yLrqXr9jY5ctlCX85o_2df3nDUC4uG7W_Y9WQ0rsaATmtlSIGe7IqWBuCkdP2Fldhu1fzl_4HZv0VoQWg7OLFA";
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                request.Headers.Add("mode", "no-cors");

                var response = await _http.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();

                var result = JsonSerializer.Deserialize<List<APIClass>>(content);

                return result;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request error: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                return null;
            }
        }
    }
}
