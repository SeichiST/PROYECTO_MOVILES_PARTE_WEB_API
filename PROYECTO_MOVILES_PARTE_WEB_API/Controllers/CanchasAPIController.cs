using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROYECTO_MOVILES_PARTE_WEB_API.Models;

namespace PROYECTO_MOVILES_PARTE_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CanchasAPIController : ControllerBase
    {
        private readonly AlquilerCanchitasContext db;

        public CanchasAPIController(AlquilerCanchitasContext _db)
        { 
            db = _db;
        }

        // GET: api/<CanchasAPIController>/GetCanchas
        [HttpGet("GetCanchas")]
        public async Task<List<Cancha>> GetCanchas()
        {
            var listado = await db.Canchas.ToListAsync();
            return listado;
        }

        // GET api/<CanchasAPIController>/GetCancha/id
        [HttpGet("GetCancha/{id}")]
        public async Task<ActionResult<Cancha>> GetCancha(int id)
        {
            var obj = await db.Canchas.FindAsync(id);
            if (obj == null)
            {
                return BadRequest("Codigo no existente");
            }
            return Ok(obj);
        }

        // POST api/<CanchasAPIController>
        [HttpPost]
        public async Task<ActionResult<Cancha>> PostCancha([FromBody] Cancha value)
        {
            try
            {
                await db.Canchas.AddAsync(value);
                await db.SaveChangesAsync();

                return Ok("Cancha agregada correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }

        // PUT api/<CanchasAPIController>
        [HttpPut]
        public async Task<ActionResult<Cancha>> PutCancha([FromBody] Cancha value)
        {
            try
            {
                await Task.Run(() => db.Canchas.Update(value));
                await db.SaveChangesAsync();
                return Ok("Cancha modificada correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }

        // DELETE api/<CanchasAPIController>/DeleteCancha/id
        [HttpDelete("DeleteCancha/{id}")]
        public async Task<ActionResult<Cancha>> DeleteCancha(int id)
        {
            try
            { 
                var buscado = await db.Canchas.FindAsync(id);

                if (buscado == null)
                {
                    return BadRequest("Codigo no existente");
                }

                db.Canchas.Remove(buscado);
                await db.SaveChangesAsync();
                return Ok("Cancha eliminada correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }
    }
}
