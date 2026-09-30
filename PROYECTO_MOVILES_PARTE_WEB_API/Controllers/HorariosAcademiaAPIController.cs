using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROYECTO_MOVILES_PARTE_WEB_API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PROYECTO_MOVILES_PARTE_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorariosAcademiaAPIController : ControllerBase
    {
        private readonly AlquilerCanchitasContext db;

        public HorariosAcademiaAPIController(AlquilerCanchitasContext _db)
        { 
            db = _db;
        }

        // GET: api/<HorariosAcademiaAPIController>/GetHorarios
        [HttpGet("GetHorarios")]
        public async Task<List<HorarioAcademia>> GetHorarios()
        {
            var listado = await db.HorarioAcademia.ToListAsync();
            return listado;
        }

        // GET api/<HorariosAcademiaAPIController>/GetHorario/id
        [HttpGet("GetHorario/{id}")]
        public async Task<ActionResult<HorarioAcademia>> GetHorario(int id)
        {
            var obj = await db.HorarioAcademia.FindAsync(id);
            if (obj == null)
            {
                return BadRequest("Codigo no existente");
            }
            return Ok(obj);
        }

        // POST api/<HorariosAcademiaAPIController>
        [HttpPost]
        public async Task<ActionResult<HorarioAcademia>> PostHorario([FromBody] HorarioAcademia value)
        {
            try
            {
               await db.HorarioAcademia.AddAsync(value);
                await db.SaveChangesAsync();

                return Ok("Horario agregado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException!.Message);
            }
        }

        // PUT api/<HorariosAcademiaAPIController>/5
        [HttpPut]
        public async Task<ActionResult<HorarioAcademia>> PutHorario([FromBody] HorarioAcademia value)
        {
            try
            {
                await Task.Run(() => db.HorarioAcademia.Update(value));
                await db.SaveChangesAsync();
                return Ok("Horario modificado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException!.Message);
            }
        }

        // DELETE api/<HorariosAcademiaAPIController>/DeleteHorario/id
        [HttpDelete("DeleteHorario/{id}")]
        public async Task<ActionResult<HorarioAcademia>> DeleteHorario(int id)
        {
            try
            { 
                var buscado = await db.HorarioAcademia.FindAsync(id);

                if (buscado == null)
                {
                    return BadRequest("Codigo no existente");
                }

                db.HorarioAcademia.Remove(buscado);
                await db.SaveChangesAsync();
                return Ok("Horario eliminado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException!.Message);
            }
        }
        
    }
}
