using SharedClasses;
using Client.Services.Interface;
using System.Net.Http.Json;

namespace Client.Services
{
    public class ProductoService : IProducto
    {
        private readonly HttpClient _http;
        public ProductoService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<ProductosDTO>> GetProdutos()
        {
            return await _http.GetFromJsonAsync<List<ProductosDTO>>("Producto/GetProductos");
        }

        public async Task<ProductoDTO> GetProductoById(long id)
        {
            return await _http.GetFromJsonAsync<ProductoDTO>($"Producto/GetProductosbyId/{id}");
        }

        public async Task<bool> PostProducto(ProductoDTO producto)
        {
            var response = await _http.PostAsJsonAsync("Producto/PostProducto", producto);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Respuesta: {result}");

                return await response.Content.ReadFromJsonAsync<bool>();
            }
            else
            {
                Console.WriteLine("Error al realizar la solicitud: " + response.StatusCode);
                return false;
            }
        }

        public async Task<bool> PutProducto(ProductoDTO producto)
        {
            var response = await _http.PutAsJsonAsync("Producto/PutProducto", producto);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Respuesta: {result}");

                return await response.Content.ReadFromJsonAsync<bool>();
            }
            else
            {
                Console.WriteLine("Error al realizar la solicitud: " + response.StatusCode);
                return false;
            }
        }

        public async Task<bool> DeleteProducto(ProductosDTO productoDelete)
        {
            var response = await _http.PutAsJsonAsync("Producto/DeleteProducto", productoDelete);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Respuesta: {result}");

                return await response.Content.ReadFromJsonAsync<bool>();
            }
            else
            {
                Console.WriteLine("Error al realizar la solicitud: " + response.StatusCode);
                return false;
            }
        }

    }
}
