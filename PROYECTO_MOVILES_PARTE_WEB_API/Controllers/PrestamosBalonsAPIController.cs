using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROYECTO_MOVILES_PARTE_WEB_API.Models;

namespace PROYECTO_MOVILES_PARTE_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamosBalonsAPIController : ControllerBase
    {
        private readonly AlquilerCanchitasContext db;

        public PrestamosBalonsAPIController(AlquilerCanchitasContext _db)
        { 
            db = _db;
        }

        // GET: api/<PrestamosBalonsAPIController>/GetPrestamos
        [HttpGet("GetPrestamos")]
        public async Task<List<PrestamoBalon>> GetPrestamos()
        {
            var listado = await db.PrestamoBalons.ToListAsync();
            return listado;
        }

        // GET api/<PrestamosBalonsAPIController>/GetPrestamo/id
        [HttpGet("GetPrestamo/{id}")]
        public async Task<ActionResult<PrestamoBalon>> GetPrestamo(int id)
        {
            var obj = await db.PrestamoBalons.FindAsync(id);
            if (obj == null)
            {
                return BadRequest("Codigo no existente");
            }
            return Ok(obj);
        }

        // POST api/<PrestamosBalonsAPIController>
        [HttpPost]
        public async Task<ActionResult<PrestamoBalon>> PostPrestamo([FromBody] PrestamoBalon value)
        {
            try
            {
                await db.PrestamoBalons.AddAsync(value);
                await db.SaveChangesAsync();

                return Ok("Prestamo agregado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }

        // PUT api/<PrestamosBalonsAPIController>
        [HttpPut]
        public async Task<ActionResult<PrestamoBalon>> PutPrestamo([FromBody] PrestamoBalon value)
        {
            try
            {
                await Task.Run(() => db.PrestamoBalons.Update(value));
                await db.SaveChangesAsync();
                return Ok("Prestamo modificado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }

        // DELETE api/<PrestamosBalonsAPIController>/DeletePrestamo/id
        [HttpDelete("DeletePrestamo/{id}")]
        public async Task<ActionResult<PrestamoBalon>> DeletePrestamo(int id)
        {
            try
            { 
                var buscado = await db.PrestamoBalons.FindAsync(id);

                if (buscado == null)
                {
                    return BadRequest("Codigo no existente");
                }

                db.PrestamoBalons.Remove(buscado);
                await db.SaveChangesAsync();
                return Ok("Prestamo eliminado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }
    }
}
