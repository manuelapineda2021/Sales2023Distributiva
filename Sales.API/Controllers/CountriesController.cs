using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.API.Data;
using Sales.shared.Entities;

namespace Sales.API.Controllers
{
    [ApiController]
    [Route("/api/countries")] //request routing
    public class CountriesController : ControllerBase
    {
        private readonly DataContext _context;

        //Inject to the database
        public CountriesController(DataContext context)
        {
            _context = context;
        }

        //Consult records
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.Countries.ToListAsync());
        }

        //Query a record with Id
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(x => x.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        //Add new record
        [HttpPost]
        public async Task<ActionResult> PostAsync(Country country)
        {
            _context.Add(country); //sends records to the database
            await _context.SaveChangesAsync(); //saves records in the database
            return Ok(country);
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Country country)
        {
            _context.Update(country);//update country
            await _context.SaveChangesAsync(); //save country update
            return Ok(country);
        }

        //Delete country
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(x => x.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            _context.Remove(country);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
