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
                _context.Countries.Add(new Country
                {
                    Name = "Colombia",
                    States = new List<State>()
                    {
                        new State()
                        {
                            Name = "Antioquia",
                            Cities = new List<City>()
                            {
                                new City() {Name = "Medellín"},
                                new City() {Name = "Itaguí"},
                                new City() {Name = "Envigado"},
                                new City() {Name = "Bello"},
                                new City() {Name = "Rionegro"}
                            }
                        },
                        new State()
                        {
                            Name = "Bogotá",
                            Cities = new List<City>()
                            {
                                new City() {Name ="Usaquen"},
                                new City() {Name ="Campinero"},
                                new City() {Name ="Santa Fe"},
                                new City() {Name ="Useme"},
                                new City() {Name ="Bosa"},
                            }
                        }
                    }
                });
                _context.Countries.Add(new Country
                {
                    Name = "Estados Unidos",
                    States = new List<State>()
                    {
                        new State()
                        {
                            Name = "Florida",
                            Cities = new List<City>()
                            {
                                new City() {Name = "Orlando"},
                                new City() {Name = "Miama"},
                                new City() {Name = "Tampa"},
                                new City() {Name = "Fort Lauderdale"},
                                new City() {Name = "Key West"},
                            }
                        },

                        new State()
                        {
                            Name = "Texas",
                            Cities = new List<City>()
                            {
                                new City() {Name = "Houston"},
                                new City() {Name = "San Antonio"},
                                new City() {Name = "Dallas"},
                                new City() {Name = "Austin"},
                                new City() {Name = "El paso"},
                            }
                        }
                    }
                }
                );
                //Crear permanent records
                await _context.SaveChangesAsync();
            }
        }
    }
}
