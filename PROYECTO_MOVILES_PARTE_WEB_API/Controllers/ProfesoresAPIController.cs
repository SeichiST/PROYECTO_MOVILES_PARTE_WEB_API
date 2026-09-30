using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROYECTO_MOVILES_PARTE_WEB_API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PROYECTO_MOVILES_PARTE_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesoresAPIController : ControllerBase
    {
        private readonly AlquilerCanchitasContext db;

        public ProfesoresAPIController(AlquilerCanchitasContext _db)
        { 
            db = _db;
        }

        // GET: api/<ProfesoresAPIController>/GetProfesores
        [HttpGet("GetProfesores")]
        public async Task<List<Profesor>> GetProfesores()
        {
            var listado = await db.Profesors.ToListAsync();
            return listado;
        }

        // GET api/<ProfesoresAPIController>/GetProfesor/id
        [HttpGet("GetProfesor/{id}")]
        public async Task<ActionResult<Profesor>> GetProfesor(int id)
        {
            var obj = await db.Profesors.FindAsync(id);
            if (obj == null)
            {
                return BadRequest("Codigo no existente");
            }
            return Ok(obj);
        }

        // POST api/<ProfesoresAPIController>
        [HttpPost]
        public async Task<ActionResult<Profesor>> PostProfesor([FromBody] Profesor value)
        {
            try
            {
               await db.Profesors.AddAsync(value);
                await db.SaveChangesAsync();

                return Ok("Profesor agregado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException!.Message);
            }
        }

        // PUT api/<ProfesoresAPIController>/5
        [HttpPut]
        public async Task<ActionResult<Profesor>> PutProfesor([FromBody] Profesor value)
        {
            try
            {
                await Task.Run(() => db.Profesors.Update(value));
                await db.SaveChangesAsync();
                return Ok("Profesor modificado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException!.Message);
            }
        }

        // DELETE api/<ProfesoresAPIController>/DeleteProfesor/id
        [HttpDelete("DeleteProfesor/{id}")]
        public async Task<ActionResult<Profesor>> DeleteProfesor(int id)
        {
            try
            { 
                var buscado = await db.Profesors.FindAsync(id);

                if (buscado == null)
                {
                    return BadRequest("Codigo no existente");
                }

                db.Profesors.Remove(buscado);
                await db.SaveChangesAsync();
                return Ok("Profesor eliminado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException!.Message);
            }
        }
        
    }
}
