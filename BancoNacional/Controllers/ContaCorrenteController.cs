using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BancoNacional.Data;
using BancoNacional.Models;

namespace BancoNacional.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaCorrenteController : ControllerBase
    {
        private readonly BancoNacionalDbContext _context;

        public ContaCorrenteController(BancoNacionalDbContext context)
        {
            _context = context;
        }

        // GET: api/ContaCorrente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContaCorrente>>> GetContaCorrente()
        {
            return await _context.ContaCorrente.ToListAsync();
        }

        // GET: api/ContaCorrente/id
        [HttpGet("{id}")]
        public async Task<ActionResult<ContaCorrente>> GetContaCorrente(int id)
        {
            var contaCorrente = await _context.ContaCorrente.FindAsync(id);

            if (contaCorrente == null)
            {
                return NotFound();
            }

            return contaCorrente;
        }

        // PUT: api/ContaCorrente/id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContaCorrente(int id, ContaCorrente contaCorrente)
        {
            if (id != contaCorrente.CODIGO_CONTA)
            {
                return BadRequest();
            }

            _context.Entry(contaCorrente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContaCorrenteExists(id))
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

        // POST: api/ContaCorrente
        [HttpPost]
        public async Task<ActionResult<ContaCorrente>> PostContaCorrente(ContaCorrente contaCorrente)
        {
            _context.ContaCorrente.Add(contaCorrente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContaCorrente", new { id = contaCorrente.CODIGO_CONTA }, contaCorrente);
        }

        // DELETE: api/ContaCorrente/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContaCorrente(int id)
        {
            var contaCorrente = await _context.ContaCorrente.FindAsync(id);
            if (contaCorrente == null)
            {
                return NotFound();
            }

            _context.ContaCorrente.Remove(contaCorrente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContaCorrenteExists(int id)
        {
            return _context.ContaCorrente.Any(e => e.CODIGO_CONTA == id);
        }
    }
}
