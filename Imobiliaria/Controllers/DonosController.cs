using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Imobiliaria.Data;
using Imobiliaria.Models;

namespace Imobiliaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonosController : ControllerBase
    {
        private readonly ApplicationDbContext _imobiliariaDb;

        public DonosController(ApplicationDbContext imobiliariaDb)
        {
            _imobiliariaDb = imobiliariaDb;
        }

        // GET: api/Donos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dono>>> GetDonos()
        {
            return await _imobiliariaDb.Donos.ToListAsync();
        }

        // GET: api/Donos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dono>> GetDono(int id)
        {
            var dono = await _imobiliariaDb.Donos.FindAsync(id);

            if (dono == null)
            {
                return NotFound();
            }

            return dono;
        }

        // PUT: api/Donos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDono(int id, Dono dono)
        {
            if (id != dono.Id)
            {
                return BadRequest();
            }

            _imobiliariaDb.Entry(dono).State = EntityState.Modified;

            try
            {
                await _imobiliariaDb.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonoExists(id))
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

        // POST: api/Donos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dono>> PostDono(Dono dono)
        {
            _imobiliariaDb.Donos.Add(dono);
            await _imobiliariaDb.SaveChangesAsync();

            return CreatedAtAction("GetDono", new { id = dono.Id }, dono);
        }

        // DELETE: api/Donos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDono(int id)
        {
            var dono = await _imobiliariaDb.Donos.FindAsync(id);
            if (dono == null)
            {
                return NotFound();
            }

            _imobiliariaDb.Donos.Remove(dono);
            await _imobiliariaDb.SaveChangesAsync();

            return NoContent();
        }

        private bool DonoExists(int id)
        {
            return _imobiliariaDb.Donos.Any(e => e.Id == id);
        }
    }
}
