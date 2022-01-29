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
    public class CitiesController : ControllerBase
    {
        private readonly ApplicationDbContext _citiesDb;

        public CitiesController(ApplicationDbContext citiesDb)
        {
            _citiesDb = citiesDb;
        }

        // GET: api/Cities
        // GET: api/Cities/?pageIndex=0&pageSize=10
        // GET: api/Cities/?pageIndex=0&pageSize=10&sortColumn=name&sortOrder=asc
        // GET: api/Cities/?pageIndex=0&pageSize=10&sortColumn=name&sortOrder=asc&filterColumn=name&filterQuery=york
        [HttpGet]
        public async Task<ActionResult<ApiResult<City>>> GetCities(
                int pageIndex = 0,
                int pageSize = 10,
                string sortColumn = null,
                string sortOrder = null,
                string filterColumn = null,
                string filterQuery = null)
        {
            return await ApiResult<City>.CreateAsync(
                    _citiesDb.Cities,
                    pageIndex,
                    pageSize,
                    sortColumn,
                    sortOrder,
                    filterColumn,
                    filterQuery);
        }

        // GET: api/Cities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetCity(int id)
        {
            var city = await _citiesDb.Cities.FindAsync(id);

            if (city == null)
            {
                return NotFound();
            }

            return city;
        }

        // PUT: api/Cities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCity(int id, City city)
        {
            if (id != city.Id)
            {
                return BadRequest();
            }

            _citiesDb.Entry(city).State = EntityState.Modified;

            try
            {
                await _citiesDb.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(id))
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

        // POST: api/Cities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<City>> PostCity(City city)
        {
            _citiesDb.Cities.Add(city);
            await _citiesDb.SaveChangesAsync();

            return CreatedAtAction("GetCity", new { id = city.Id }, city);
        }

        // DELETE: api/Cities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<City>> DeleteCity(int id)
        {
            var city = await _citiesDb.Cities.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }

            _citiesDb.Cities.Remove(city);
            await _citiesDb.SaveChangesAsync();

            return NoContent();
        }

        private bool CityExists(int id)
        {
            return _citiesDb.Cities.Any(e => e.Id == id);
        }

        [HttpPost]
        [Route("IsDupeCity")]
        public bool IsDupeCity(City city)
        {
            return _citiesDb.Cities.Any(
                e => e.Name == city.Name &&
                     e.Lat  == city.Lat  &&
                     e.Lon  == city.Lon  &&
                     e.CountryId == city.CountryId &&
                     e.Id != city.Id);
        }
    }
}
