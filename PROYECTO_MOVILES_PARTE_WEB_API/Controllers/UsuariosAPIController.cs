using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROYECTO_MOVILES_PARTE_WEB_API.Models;

namespace PROYECTO_MOVILES_PARTE_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosAPIController : ControllerBase
    {
        private readonly AlquilerCanchitasContext db;

        public UsuariosAPIController(AlquilerCanchitasContext _db)
        { 
            db = _db;
        }

        // GET: api/<UsuariosAPIController>/GetUsuarios
        [HttpGet("GetUsuarios")]
        public async Task<List<Usuario>> GetUsuarios()
        {
            var listado = await db.Usuarios.ToListAsync();
            return listado;
        }

        // GET api/<UsuariosAPIController>/GetUsuario/id
        [HttpGet("GetUsuario/{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var obj = await db.Usuarios.FindAsync(id);
            if (obj == null)
            {
                return BadRequest("Codigo no existente");
            }
            return Ok(obj);
        }

        // POST api/<UsuariosAPIController>
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario([FromBody] Usuario value)
        {
            try
            {
                await db.Usuarios.AddAsync(value);
                await db.SaveChangesAsync();

                return Ok("Usuario agregado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }

        // PUT api/<UsuariosAPIController>
        [HttpPut]
        public async Task<ActionResult<Usuario>> PutUsuario([FromBody] Usuario value)
        {
            try
            {
                await Task.Run(() => db.Usuarios.Update(value));
                await db.SaveChangesAsync();
                return Ok("Usuario modificado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }

        // DELETE api/<UsuariosAPIController>/DeleteUsuario/id
        [HttpDelete("DeleteUsuario/{id}")]
        public async Task<ActionResult<Usuario>> DeleteUsuario(int id)
        {
            try
            { 
                var buscado = await db.Usuarios.FindAsync(id);

                if (buscado == null)
                {
                    return BadRequest("Codigo no existente");
                }

                db.Usuarios.Remove(buscado);
                await db.SaveChangesAsync();
                return Ok("Usuario eliminado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }
    }
}
