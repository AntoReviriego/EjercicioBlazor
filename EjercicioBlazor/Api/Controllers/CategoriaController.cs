using Api.Entity;
using Api.Entity.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedClasses;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly DBContext _dbContext;

        public CategoriaController(DBContext db)
        {
            _dbContext = db;
        }

        [HttpGet]
        [Route("GetCategoria")]
        public async Task<ActionResult> GetCategoria()
        {
            try
            {
                List<CategoriaDTO> categoria = await _dbContext.Categoria.Where(x => x.Enable).Select(x => new CategoriaDTO()
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion,
                    InsertDate = x.InsertDate,
                    UpdateDate = x.UpdateDate,
                    Enable = x.Enable
                }).ToListAsync();
                return Ok(categoria);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Api GetMarcas - Error: {0}", ex.Message.ToString());
                return Ok(new List<CategoriaDTO>());
            }
        }
    }
}
