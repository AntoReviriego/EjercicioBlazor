using Api.Entity;
using Api.Entity.Context;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedClasses;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MarcaController : ControllerBase
    {
        private readonly DBContext _dbContext;

        public MarcaController(DBContext db)
        {
            _dbContext = db;
        }

        [HttpGet]
        [Route("GetMarcas")]
        public async Task<ActionResult> GetMarcas()
        {
            try
            {
                List<MarcaDTO> marcas = await _dbContext.Marcas.Where(x => x.Enable).Select(x => new MarcaDTO()
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion,
                    InsertDate = x.InsertDate,
                    UpdateDate = x.UpdateDate,
                    Enable = x.Enable,

                }).ToListAsync();
                return Ok(marcas);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Api GetMarcas - Error: {0}", ex.Message.ToString());
                return Ok(new List<MarcaDTO>());
            }
        }
    }
}
