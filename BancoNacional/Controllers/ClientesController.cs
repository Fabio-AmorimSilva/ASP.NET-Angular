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
    public class ClientesController : ControllerBase
    {
        private readonly BancoNacionalDbContext _context;

        public ClientesController(BancoNacionalDbContext context)
        {
            _context = context;

        }

        //GET api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clientes>>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();

        }

        //GET api/Clientes/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Clientes>> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return BadRequest();
            }

            return cliente;

        }
        
        //PUT api/Clientes/id
        [HttpPut("{id}")]
        public async Task<ActionResult<Clientes>> PutCliente(int id, Clientes cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }


            _context.Entry(cliente).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NotFound();

        }

        //POST api/Clientes
        [HttpPost]
        public async Task<ActionResult<Clientes>> PostCliente(Clientes cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetCliente", new { CODIGO_CLIENTE = cliente.Id}, cliente);

        }

        //DELELTE api/Clientes/id
        [HttpDelete("{id}")]
        public async Task<ActionResult<Clientes>> RemoveCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return BadRequest();
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();

        }

        public bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.Id == id);
        }


    }
}
