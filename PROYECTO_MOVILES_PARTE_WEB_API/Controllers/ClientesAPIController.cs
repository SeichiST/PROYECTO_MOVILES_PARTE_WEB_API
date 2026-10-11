using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROYECTO_MOVILES_PARTE_WEB_API.Models;

namespace PROYECTO_MOVILES_PARTE_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesAPIController : ControllerBase
    {
        private readonly AlquilerCanchitasContext db;

        public ClientesAPIController(AlquilerCanchitasContext _db)
        { 
            db = _db;
        }

        // GET: api/<ClientesAPIController>/GetClientes
        [HttpGet("GetClientes")]
        public async Task<List<Cliente>> GetClientes()
        {
            var listado = await db.Clientes.ToListAsync();
            return listado;
        }

        // GET api/<ClientesAPIController>/GetCliente/id
        [HttpGet("GetCliente/{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var obj = await db.Clientes.FindAsync(id);
            if (obj == null)
            {
                return BadRequest("Codigo no existente");
            }
            return Ok(obj);
        }

        // POST api/<ClientesAPIController>
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente([FromBody] Cliente value)
        {
            try
            {
                await db.Clientes.AddAsync(value);
                await db.SaveChangesAsync();

                return Ok("Cliente agregado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }

        // PUT api/<ClientesAPIController>
        [HttpPut]
        public async Task<ActionResult<Cliente>> PutCliente([FromBody] Cliente value)
        {
            try
            {
                await Task.Run(() => db.Clientes.Update(value));
                await db.SaveChangesAsync();
                return Ok("Cliente modificado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }

        // DELETE api/<ClientesAPIController>/DeleteCliente/id
        [HttpDelete("DeleteCliente/{id}")]
        public async Task<ActionResult<Cliente>> DeleteCliente(int id)
        {
            try
            { 
                var buscado = await db.Clientes.FindAsync(id);

                if (buscado == null)
                {
                    return BadRequest("Codigo no existente");
                }

                db.Clientes.Remove(buscado);
                await db.SaveChangesAsync();
                return Ok("Cliente eliminado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }
    }
}
