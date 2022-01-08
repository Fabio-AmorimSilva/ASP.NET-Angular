using BancoNacional.Data;
using BancoNacional.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoNacional.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgenciasController : ControllerBase
    {
        private readonly BancoNacionalDbContext _context;

        public AgenciasController(BancoNacionalDbContext context)
        {
            _context = context;

        }

        //GET api/Agencias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agencias>>> GetAgencias()
        {
            return await _context.Agencias.ToListAsync();
        }

        //GET api/Agencias/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Agencias>> GetAgencia(int id)
        {
            var agencia = await _context.Agencias.FindAsync(id);

            if(agencia == null)
            {
                return NotFound();
            }

            return agencia;
        }

        //PUT api/Agencias/id
        [HttpPut("{id}")]
        public async Task<ActionResult<Agencias>> PutAgencia(int id, Agencias agencia)
        {
            if(id != agencia.Id)
            {
                return BadRequest();
            }

            _context.Entry(agencia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgenciaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }

            return NoContent();

        }

        //POST api/Agencias
        [HttpPost]
        public async Task<ActionResult<Agencias>> PostAgencia(Agencias agencia)
        {
            _context.Agencias.Add(agencia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAgencia", new { CODIGO_AGENCIA = agencia.Id }, agencia);

        }

        //DELETE api/Agencias/id
        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveAgencia(int id)
        {
            var agencia = await _context.Agencias.FindAsync(id);
            if(agencia == null)
            {
                return NotFound();
            }

            _context.Agencias.Remove(agencia);
            await _context.SaveChangesAsync();

            return NoContent();

        }

        private bool AgenciaExists(int id)
        {
            return _context.Agencias.Any(e => e.Id == id);

        }

    }
}
