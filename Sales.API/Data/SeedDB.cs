using Sales.shared.Entities;

namespace Sales.API.Data
{
    public class SeedDB
    {
        private readonly DataContext _context;

        public SeedDB(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync(); //replaces the console command: update-database
            await CheckCountriesAsync();
            await CheckCategoriesAsync();
        }

        private async Task CheckCategoriesAsync()
        {
            if (!_context.Categories.Any())
            {
                _context.Categories.Add(new Category { Name = "Zapatos" });
                _context.Categories.Add(new Category { Name = "Televisores" });
                _context.Categories.Add(new Category { Name = "Celulares" });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckCountriesAsync()
        {
            //No records
            if (!_context.Countries.Any())
            {
                //permanent countries (not yet created in database)
                _context.Countries.Add(new Country { Name = "Colombia" });
                _context.Countries.Add(new Country { Name = "Perú" });
                _context.Countries.Add(new Country { Name = "México" });

                //Crear permanent countries
                await _context.SaveChangesAsync();
            }
        }
    }
}
