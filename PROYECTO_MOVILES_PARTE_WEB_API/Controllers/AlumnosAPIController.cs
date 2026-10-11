using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROYECTO_MOVILES_PARTE_WEB_API.Models;

namespace PROYECTO_MOVILES_PARTE_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosAPIController : ControllerBase
    {
        private readonly AlquilerCanchitasContext db;

        public AlumnosAPIController(AlquilerCanchitasContext _db)
        { 
            db = _db;
        }

        // GET: api/<AlumnosAPIController>/GetAlumnos
        [HttpGet("GetAlumnos")]
        public async Task<List<Alumno>> GetAlumnos()
        {
            var listado = await db.Alumnos.ToListAsync();
            return listado;
        }

        // GET api/<AlumnosAPIController>/GetAlumno/id
        [HttpGet("GetAlumno/{id}")]
        public async Task<ActionResult<Alumno>> GetAlumno(int id)
        {
            var obj = await db.Alumnos.FindAsync(id);
            if (obj == null)
            {
                return BadRequest("Codigo no existente");
            }
            return Ok(obj);
        }

        // POST api/<AlumnosAPIController>
        [HttpPost]
        public async Task<ActionResult<Alumno>> PostAlumno([FromBody] Alumno value)
        {
            try
            {
                await db.Alumnos.AddAsync(value);
                await db.SaveChangesAsync();

                return Ok("Alumno agregado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }

        // PUT api/<AlumnosAPIController>
        [HttpPut]
        public async Task<ActionResult<Alumno>> PutAlumno([FromBody] Alumno value)
        {
            try
            {
                await Task.Run(() => db.Alumnos.Update(value));
                await db.SaveChangesAsync();
                return Ok("Alumno modificado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }

        // DELETE api/<AlumnosAPIController>/DeleteAlumno/id
        [HttpDelete("DeleteAlumno/{id}")]
        public async Task<ActionResult<Alumno>> DeleteAlumno(int id)
        {
            try
            { 
                var buscado = await db.Alumnos.FindAsync(id);

                if (buscado == null)
                {
                    return BadRequest("Codigo no existente");
                }

                db.Alumnos.Remove(buscado);
                await db.SaveChangesAsync();
                return Ok("Alumno eliminado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }
    }
}
