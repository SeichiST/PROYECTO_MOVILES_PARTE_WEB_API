using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROYECTO_MOVILES_PARTE_WEB_API.Models;

namespace PROYECTO_MOVILES_PARTE_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasAPIController : ControllerBase
    {
        private readonly AlquilerCanchitasContext db;

        public ReservasAPIController(AlquilerCanchitasContext _db)
        { 
            db = _db;
        }

        // GET: api/<ReservasAPIController>/GetReservas
        [HttpGet("GetReservas")]
        public async Task<List<Reserva>> GetReservas()
        {
            var listado = await db.Reservas.ToListAsync();
            return listado;
        }

        // GET api/<ReservasAPIController>/GetReserva/id
        [HttpGet("GetReserva/{id}")]
        public async Task<ActionResult<Reserva>> GetReserva(int id)
        {
            var obj = await db.Reservas.FindAsync(id);
            if (obj == null)
            {
                return BadRequest("Codigo no existente");
            }
            return Ok(obj);
        }

        // POST api/<ReservasAPIController>
        [HttpPost]
        public async Task<ActionResult<Reserva>> PostReserva([FromBody] Reserva value)
        {
            try
            {
                await db.Reservas.AddAsync(value);
                await db.SaveChangesAsync();

                return Ok("Reserva agregada correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }

        // PUT api/<ReservasAPIController>
        [HttpPut]
        public async Task<ActionResult<Reserva>> PutReserva([FromBody] Reserva value)
        {
            try
            {
                await Task.Run(() => db.Reservas.Update(value));
                await db.SaveChangesAsync();
                return Ok("Reserva modificada correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }

        // DELETE api/<ReservasAPIController>/DeleteReserva/id
        [HttpDelete("DeleteReserva/{id}")]
        public async Task<ActionResult<Reserva>> DeleteReserva(int id)
        {
            try
            { 
                var buscado = await db.Reservas.FindAsync(id);

                if (buscado == null)
                {
                    return BadRequest("Codigo no existente");
                }

                db.Reservas.Remove(buscado);
                await db.SaveChangesAsync();
                return Ok("Reserva eliminada correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }
    }
}
