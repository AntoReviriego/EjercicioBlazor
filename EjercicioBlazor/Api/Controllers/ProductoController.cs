using Api.Entity;
using Api.Entity.Context;
using Api.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly DBContext _dbContext;

        public ProductoController(DBContext db)
        {
            _dbContext = db;
        }

        [HttpGet]
        [Route("GetProductos")]
        public async Task<ActionResult> GetProductos()
        {
            try
            {
                List<ProductosDTO> productos = await _dbContext.Productos.Where(x => x.Enable)
                                                            .Include(x => x.IdMarcaNavigation)
                                                            .Include(x => x.IdCategoriaNavigation)
                                                            .Select(x => new ProductosDTO()
                                                            {
                                                                Id = x.Id,
                                                                Code = x.Code,
                                                                Descripcion = x.Descripcion,
                                                                Marca = x.IdMarcaNavigation.Descripcion,
                                                                Categoria = x.IdCategoriaNavigation.Descripcion,
                                                                InsertDate = x.InsertDate,
                                                                UpdateDate = (DateTime)x.UpdateDate,
                                                            })
                                                            .ToListAsync();
                return Ok(productos);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Api GetProductos - Error: {0}", ex.Message.ToString());
                return Ok(new List<ProductosDTO>());
            }
        }

        [HttpGet]
        [Route("GetProductosbyId/{id}")]
        public async Task<ActionResult> GetProductosById(long id)
        {
            try
            {
                List<Producto> productos = await _dbContext.Productos.Where(x => x.Id == id && x.Enable)
                                                            .Include(x => x.IdMarcaNavigation)
                                                            .Include(x => x.IdCategoriaNavigation)
                                                            .ToListAsync();
                return Ok(productos);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Api GetProductosById - Error: {0}", ex.Message.ToString());
                return Ok(new List<ProductosDTO>());
            }
        }

        [HttpPost]
        [Route("PostProducto")]
        public async Task<ActionResult> PostProducto([FromBody] ProductoDTO producto)
        {
            try
            {
                if (producto == null)
                {
                    return Ok(false);
                }

                var newProducto = new Producto
                {
                    Code = producto.Code,
                    Descripcion = producto.Descripcion,
                    Precio = producto.Precio,
                    IdMarca = producto.IdMarca,
                    IdCategoria = producto.IdCategoria,
                    InsertDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    Enable = true
                };

                _dbContext.Productos.Add(newProducto);
                await _dbContext.SaveChangesAsync();
                return Ok(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Api PostProducto - Error: {0}", ex.Message.ToString());
                return Ok(false);
            }
        }
    }
}
