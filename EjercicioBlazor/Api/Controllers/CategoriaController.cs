using Api.Entity;
using Api.Entity.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                List<Categorium> categoria = await _dbContext.Categoria.Where(x => x.Enable).ToListAsync();
                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return Ok(new List<Categorium>());
            }
        }
    }
}
