using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROYECTO_MOVILES_PARTE_WEB_API.Models;

namespace PROYECTO_MOVILES_PARTE_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsistenciasAPIController : ControllerBase
    {
        private readonly AlquilerCanchitasContext db;

        public AsistenciasAPIController(AlquilerCanchitasContext _db)
        { 
            db = _db;
        }

        // GET: api/<AsistenciasAPIController>/GetAsistencias
        [HttpGet("GetAsistencias")]
        public async Task<List<Asistencia>> GetAsistencias()
        {
            var listado = await db.Asistencias.ToListAsync();
            return listado;
        }

        // GET api/<AsistenciasAPIController>/GetAsistencia/id
        [HttpGet("GetAsistencia/{id}")]
        public async Task<ActionResult<Asistencia>> GetAsistencia(int id)
        {
            var obj = await db.Asistencias.FindAsync(id);
            if (obj == null)
            {
                return BadRequest("Codigo no existente");
            }
            return Ok(obj);
        }

        // POST api/<AsistenciasAPIController>
        [HttpPost]
        public async Task<ActionResult<Asistencia>> PostAsistencia([FromBody] Asistencia value)
        {
            try
            {
                await db.Asistencias.AddAsync(value);
                await db.SaveChangesAsync();

                return Ok("Asistencia agregada correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }

        // PUT api/<AsistenciasAPIController>
        [HttpPut]
        public async Task<ActionResult<Asistencia>> PutAsistencia([FromBody] Asistencia value)
        {
            try
            {
                await Task.Run(() => db.Asistencias.Update(value));
                await db.SaveChangesAsync();
                return Ok("Asistencia modificada correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }

        // DELETE api/<AsistenciasAPIController>/DeleteAsistencia/id
        [HttpDelete("DeleteAsistencia/{id}")]
        public async Task<ActionResult<Asistencia>> DeleteAsistencia(int id)
        {
            try
            { 
                var buscado = await db.Asistencias.FindAsync(id);

                if (buscado == null)
                {
                    return BadRequest("Codigo no existente");
                }

                db.Asistencias.Remove(buscado);
                await db.SaveChangesAsync();
                return Ok("Asistencia eliminada correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }
    }
}
