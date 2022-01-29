using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorldCities.Data;
using WorldCities.Data.Models;

namespace WorldCities.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ApplicationDbContext _countriesDb;

        public CountriesController(ApplicationDbContext countriesDb)
        {
            _countriesDb = countriesDb;
        }

        // GET: api/Cities
        // GET: api/Countries/?pageIndex=0&pageSize=10
        // GET: api/Countries/?pageIndex=0&pageSize=10&sortColumn=name&sortOrder=asc
        // GET: api/Countries/?pageIndex=0&pageSize=10&sortColumn=name&sortOrder=asc&filterColumn=name&filterQuery=york
        [HttpGet]
        public async Task<ActionResult<ApiResult<Country>>> GetCountries(
                int pageIndex = 0,
                int pageSize = 10,
                string sortColumn = null,
                string sortOrder = null,
                string filterColumn = null,
                string filterQuery = null)
        {
            return await ApiResult<Country>.CreateAsync(
                    _countriesDb.Countries,
                    pageIndex,
                    pageSize,
                    sortColumn,
                    sortOrder,
                    filterColumn,
                    filterQuery);
        }


        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            var country = await _countriesDb.Countries.FindAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            return country;
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, Country country)
        {
            if (id != country.Id)
            {
                return BadRequest();
            }

            _countriesDb.Entry(country).State = EntityState.Modified;

            try
            {
                await _countriesDb.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(id))
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

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(Country country)
        {
            _countriesDb.Countries.Add(country);
            await _countriesDb.SaveChangesAsync();

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Country>> DeleteCountry(int id)
        {
            var country = await _countriesDb.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            _countriesDb.Countries.Remove(country);
            await _countriesDb.SaveChangesAsync();

            return NoContent();
        }

        private bool CountryExists(int id)
        {
            return _countriesDb.Countries.Any(e => e.Id == id);
        }

        [HttpPost]
        [Route("IsDupeField")]
        public bool IsDupeField(
            int countryId,
            string fieldName,
            string fieldValue)
        {
            switch(fieldName){
                case "name":
                    return _context.Countries.Any(
                        c => c.Name == fieldValue && c.Id != countryId);
                case "iso2":
                    return _context.Countries.Any(
                        c => c.ISO2 == fieldValue && c.Id != countryId);
                case "iso3":
                    return _context.Countries.Any(
                        c => c.ISO3 == fieldValue && c.Id != countryId);
                default:
                    return false;
            }
        }
    }
}
