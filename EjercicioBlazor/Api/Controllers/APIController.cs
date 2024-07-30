using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class APIController : ControllerBase
    {
        [HttpGet]
        [Route("GetAPI/{urlAPI}")]
        public async Task<ActionResult> GetAPI(string urlAPI)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.estadisticasbcra.com");
                string token = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE3NTM4NDQ0NDYsInR5cGUiOiJleHRlcm5hbCIsInVzZXIiOiJhbnRvcmV2aXJpZWdvQGdtYWlsLmNvbSJ9.yLrqXr9jY5ctlCX85o_2df3nDUC4uG7W_Y9WQ0rsaATmtlSIGe7IqWBuCkdP2Fldhu1fzl_4HZv0VoQWg7OLFA";
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                try
                {
                    HttpResponseMessage response = await client.GetAsync(urlAPI);
                    string responseBody = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine(responseBody);
                        return Ok(responseBody);
                    }
                    else
                    {
                        Console.WriteLine($"Error: {(int)response.StatusCode} - {response.ReasonPhrase}");
                        return StatusCode((int)response.StatusCode, responseBody);
                    }
                }
                catch (HttpRequestException e)
                {
                    // Manejar excepciones de solicitud HTTP
                    Console.WriteLine($"Request error: {e.Message}");
                    return StatusCode(500, "Error en la solicitud: " + e.Message);
                }
            }
        }
    }
}
