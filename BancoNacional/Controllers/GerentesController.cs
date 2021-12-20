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
    public class GerentesController : ControllerBase
    {
        private readonly BancoNacionalDbContext _context;

        public GerentesController(BancoNacionalDbContext context)
        {
            _context = context;
        }

        //GET api/Gerentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gerentes>>> GetGerentes()
        {
            return await _context.Gerentes.ToListAsync();
        }

        //GET api/Gerentes/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Gerentes>> GetGerente(int id)
        {
            var gerente = await _context.Gerentes.FindAsync(id);
            if (gerente == null)
            {
                return BadRequest();
            }

            return gerente;
        }

        //PUT api/Gerentes/id
        [HttpPut("{id}")]
        public async Task<ActionResult<Gerentes>> PutGerente(int id, Gerentes gerente)
        {
            if(id != gerente.CODIGO_GERENTE)
            {
                return BadRequest();
            }

            _context.Entry(gerente).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();

        }

        //DELETE api/Gerentes/id
        [HttpDelete("{id}")]
        public async Task<ActionResult<Gerentes>> RemoveGerentes(int id)
        {
            var gerente = await _context.Gerentes.FindAsync(id);
            if (gerente == null) 
            {
                return BadRequest();
            }

            _context.Gerentes.Remove(gerente);
            await _context.SaveChangesAsync();

            return NoContent();

        }

        //POST api/Gerentes
        [HttpPost]
        public async Task<ActionResult<Gerentes>> PostGerente(Gerentes gerente)
        {
            _context.Gerentes.Add(gerente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGerente", new { CODIGO_GERENTE = gerente.CODIGO_GERENTE }, gerente);

        }

        public bool GerenteExists(int id)
        {
            return _context.Gerentes.Any(e => e.CODIGO_GERENTE == id);
        }

    }
}
