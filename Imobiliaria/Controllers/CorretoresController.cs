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
    public class CorretoresController : ControllerBase
    {
        private readonly ApplicationDbContext _imobiliariaDb;

        public CorretoresController(ApplicationDbContext imobiliariaDb)
        {
            _imobiliariaDb = imobiliariaDb;
        }

        // GET: api/Corretores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Corretor>>> GetCorretores()
        {
            return await _imobiliariaDb.Corretores.ToListAsync();
        }

        // GET: api/Corretores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Corretor>> GetCorretor(int id)
        {
            var corretor = await _imobiliariaDb.Corretores.FindAsync(id);

            if (corretor == null)
            {
                return NotFound();
            }

            return corretor;
        }

        // PUT: api/Corretores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCorretor(int id, Corretor corretor)
        {
            if (id != corretor.Id)
            {
                return BadRequest();
            }

            _imobiliariaDb.Entry(corretor).State = EntityState.Modified;

            try
            {
                await _imobiliariaDb.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CorretorExists(id))
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

        // POST: api/Corretores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Corretor>> PostCorretor(Corretor corretor)
        {
            _imobiliariaDb.Corretores.Add(corretor);
            await _imobiliariaDb.SaveChangesAsync();

            return CreatedAtAction("GetCorretor", new { id = corretor.Id }, corretor);
        }

        // DELETE: api/Corretores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCorretor(int id)
        {
            var corretor = await _imobiliariaDb.Corretores.FindAsync(id);
            if (corretor == null)
            {
                return NotFound();
            }

            _imobiliariaDb.Corretores.Remove(corretor);
            await _imobiliariaDb.SaveChangesAsync();

            return NoContent();
        }

        private bool CorretorExists(int id)
        {
            return _imobiliariaDb.Corretores.Any(e => e.Id == id);
        }
    }
}
