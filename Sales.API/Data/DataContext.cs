using Microsoft.EntityFrameworkCore;
using Sales.shared.Entities;

namespace Sales.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions <DataContext> options) :base(options)
        {

        }

        public DbSet<Country> Countries { get; set; }

        //Validate duplicates to Country table
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(x => x.Name).IsUnique(); // create index and unique for Country table
        }
    }
}
