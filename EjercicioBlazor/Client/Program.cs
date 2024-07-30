using Client;
using Client.Services;
using Client.Services.Interface;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5053") });

builder.Services.AddScoped<IProducto, ProductoService>();
builder.Services.AddScoped<IMarca, MarcaService>();
builder.Services.AddScoped<ICategoria, CategoriaService>();

builder.Services.AddScoped<BRCA_APIService>();

// Servicio de alerts
builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();
