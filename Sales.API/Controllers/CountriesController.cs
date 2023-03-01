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

        //Add records
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.Countries.ToListAsync());
        }

        //Add new record
        [HttpPost]
        public async Task<ActionResult> PostAsync(Country country)
        {
            _context.Add(country); //sends records to the database
            await _context.SaveChangesAsync(); //saves records in the database
            return Ok(country);
        }
    }
}
