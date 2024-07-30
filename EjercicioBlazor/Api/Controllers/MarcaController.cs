using Api.Entity;
using Api.Entity.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                List<Marca> marcas = await _dbContext.Marcas.Where(x => x.Enable).ToListAsync();
                return Ok(marcas);
            }
            catch (Exception ex)
            {
                return Ok(new List<Marca>());
            }
        }
    }
}
