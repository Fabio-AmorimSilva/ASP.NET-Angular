using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Imobiliaria.Data;
using Imobiliaria.Models;
using Microsoft.AspNetCore.Authorization;

namespace Imobiliaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgenciasController : ControllerBase
    {
        private readonly ApplicationDbContext _imobiliariaDb;

        public AgenciasController(ApplicationDbContext imobiliariaDb)
        {
            _imobiliariaDb = imobiliariaDb;
        }

        // GET: api/Agencias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agencia>>> GetAgencias()
        {
            return await _imobiliariaDb.Agencias.ToListAsync();
        }

        // GET: api/Agencias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Agencia>> GetAgencia(int id)
        {
            var agencia = await _imobiliariaDb.Agencias.FindAsync(id);

            if (agencia == null)
            {
                return NotFound();
            }

            return agencia;
        }

        // PUT: api/Agencias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgencia(int id, Agencia agencia)
        {
            if (id != agencia.Id)
            {
                return BadRequest();
            }

            _imobiliariaDb.Entry(agencia).State = EntityState.Modified;

            try
            {
                await _imobiliariaDb.SaveChangesAsync();
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

        // POST: api/Agencias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Agencia>> PostAgencia(Agencia agencia)
        {
            _imobiliariaDb.Agencias.Add(agencia);
            await _imobiliariaDb.SaveChangesAsync();

            return CreatedAtAction("GetAgencia", new { id = agencia.Id }, agencia);
        }

        // DELETE: api/Agencias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgencia(int id)
        {
            var agencia = await _imobiliariaDb.Agencias.FindAsync(id);
            if (agencia == null)
            {
                return NotFound();
            }

            _imobiliariaDb.Agencias.Remove(agencia);
            await _imobiliariaDb.SaveChangesAsync();

            return NoContent();
        }

        private bool AgenciaExists(int id)
        {
            return _imobiliariaDb.Agencias.Any(e => e.Id == id);
        }
    }
}
