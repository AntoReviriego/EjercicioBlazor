using Api.Entity;
using Api.Entity.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedClasses;
using System.Text.Json.Serialization;

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
                                                                Cantidad = x.Cantidad,
                                                                Descripcion = x.Descripcion,
                                                                Precio = x.Precio,
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
                ProductoDTO? productos = await _dbContext.Productos.Where(x => x.Id == id && x.Enable)
                                                            .Include(x => x.IdMarcaNavigation)
                                                            .Include(x => x.IdCategoriaNavigation)
                                                            .Select(x => new ProductoDTO()
                                                            {
                                                                Id = x.Id,
                                                                Descripcion = x.Descripcion,
                                                                Code = x.Code,
                                                                Cantidad = x.Cantidad,
                                                                IdCategoria = x.IdCategoria,
                                                                IdMarca = x.IdMarca,
                                                                Precio = x.Precio,
                                                            })
                                                            .FirstOrDefaultAsync();
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
                    Cantidad = producto.Cantidad,
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

        [HttpPut]
        [Route("DeleteProducto")]
        public async Task<ActionResult> DeleteProducto(ProductosDTO prod)
        {
            try
            {
                if (prod.Id == 0)
                {
                    return Ok(false);
                }

                var producto = await _dbContext.Productos.FirstOrDefaultAsync(x => x.Id == prod.Id);

                if (producto != null)
                {
                    producto.Enable = false;
                    producto.UpdateDate = DateTime.Now;
                    _dbContext.Productos.Update(producto);
                    await _dbContext.SaveChangesAsync();
                    return Ok(true);
                }
                else
                {
                    Console.WriteLine("Api DeleteProducto: Producto no encontrado");
                    return Ok(false);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Api DeleteProducto - Error: {0}", ex.Message.ToString());
                return Ok(false);
            }
        }

        [HttpPut]
        [Route("PutProducto")]
        public async Task<ActionResult> PutProducto(ProductoDTO prod)
        {
            try
            {
                if (prod.Id == 0 || prod.Id == null)
                {
                    Console.WriteLine("Api PutProducto: Objeto recibido invalido.");
                    return Ok(false);
                }

                var producto = await _dbContext.Productos.FirstOrDefaultAsync(x => x.Id == prod.Id);

                if (producto != null)
                {
                    producto.Code = prod.Code;
                    producto.Descripcion = prod.Descripcion;
                    producto.Cantidad = prod.Cantidad;
                    producto.IdMarca = prod.IdMarca;
                    producto.IdCategoria = prod.IdCategoria;
                    producto.UpdateDate = DateTime.Now;
                    _dbContext.Productos.Update(producto);
                    await _dbContext.SaveChangesAsync();
                    return Ok(true);
                }
                else
                {
                    Console.WriteLine("Api PutProducto: Producto no encontrado");
                    return Ok(false);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Api PutProducto - Error: {0}", ex.Message.ToString());
                return Ok(false);
            }
        }
    }
}
