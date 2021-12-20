﻿using System;
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
    public class ContaPoupancaController : ControllerBase
    {
        private readonly BancoNacionalDbContext _context;

        public ContaPoupancaController(BancoNacionalDbContext context)
        {
            _context = context;
        }

        // GET: api/ContaPoupanca
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContaPoupanca>>> GetContaPoupanca()
        {
            return await _context.contaPoupanca.ToListAsync();
        }

        // GET: api/ContaPoupanca/id
        [HttpGet("{id}")]
        public async Task<ActionResult<ContaPoupanca>> GetContaPoupanca(int id)
        {
            var contaPoupanca = await _context.contaPoupanca.FindAsync(id);

            if (contaPoupanca == null)
            {
                return NotFound();
            }

            return contaPoupanca;
        }

        // PUT: api/ContaPoupanca/id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContaPoupanca(int id, ContaPoupanca contaPoupanca)
        {
            if (id != contaPoupanca.CODIGO_CONTA)
            {
                return BadRequest();
            }

            _context.Entry(contaPoupanca).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContaPoupancaExists(id))
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

        // POST: api/ContaPoupanca
        [HttpPost]
        public async Task<ActionResult<ContaPoupanca>> PostContaPoupanca(ContaPoupanca contaPoupanca)
        {
            _context.contaPoupanca.Add(contaPoupanca);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContaPoupanca", new { id = contaPoupanca.CODIGO_CONTA }, contaPoupanca);
        }

        // DELETE: api/ContaPoupanca/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContaPoupanca(int id)
        {
            var contaPoupanca = await _context.contaPoupanca.FindAsync(id);
            if (contaPoupanca == null)
            {
                return NotFound();
            }

            _context.contaPoupanca.Remove(contaPoupanca);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContaPoupancaExists(int id)
        {
            return _context.contaPoupanca.Any(e => e.CODIGO_CONTA == id);
        }
    }
}
