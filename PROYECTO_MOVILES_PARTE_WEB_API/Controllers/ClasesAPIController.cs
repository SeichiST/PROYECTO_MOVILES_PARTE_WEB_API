using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROYECTO_MOVILES_PARTE_WEB_API.Models;

namespace PROYECTO_MOVILES_PARTE_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClasesAPIController : ControllerBase
    {
        private readonly AlquilerCanchitasContext db;

        public ClasesAPIController(AlquilerCanchitasContext _db)
        { 
            db = _db;
        }

        // GET: api/<ClasesAPIController>/GetClases
        [HttpGet("GetClases")]
        public async Task<List<Clase>> GetClases()
        {
            var listado = await db.Clases.ToListAsync();
            return listado;
        }

        // GET api/<ClasesAPIController>/GetClase/id
        [HttpGet("GetClase/{id}")]
        public async Task<ActionResult<Clase>> GetClase(int id)
        {
            var obj = await db.Clases.FindAsync(id);
            if (obj == null)
            {
                return BadRequest("Codigo no existente");
            }
            return Ok(obj);
        }

        // POST api/<ClasesAPIController>
        [HttpPost]
        public async Task<ActionResult<Clase>> PostClase([FromBody] Clase value)
        {
            try
            {
                await db.Clases.AddAsync(value);
                await db.SaveChangesAsync();

                return Ok("Clase agregada correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }

        // PUT api/<ClasesAPIController>
        [HttpPut]
        public async Task<ActionResult<Clase>> PutClase([FromBody] Clase value)
        {
            try
            {
                await Task.Run(() => db.Clases.Update(value));
                await db.SaveChangesAsync();
                return Ok("Clase modificada correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }

        // DELETE api/<ClasesAPIController>/DeleteClase/id
        [HttpDelete("DeleteClase/{id}")]
        public async Task<ActionResult<Clase>> DeleteClase(int id)
        {
            try
            { 
                var buscado = await db.Clases.FindAsync(id);

                if (buscado == null)
                {
                    return BadRequest("Codigo no existente");
                }

                db.Clases.Remove(buscado);
                await db.SaveChangesAsync();
                return Ok("Clase eliminada correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }
    }
}
