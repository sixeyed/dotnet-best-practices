using Microsoft.EntityFrameworkCore;

namespace WorldWideImporters.Data
{
    public class WorldWideImportersContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }

        public DbSet<StateProvince> StateProvinces { get; set; }

        public DbSet<City> Cities { get; set; }

        public WorldWideImportersContext(DbContextOptions<WorldWideImportersContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema("Application");

            builder.Entity<Country>()
                .ToTable("Countries")
                .HasMany(x => x.StateProvinces)
                .WithOne(y => y.Country)
                .HasForeignKey(y => y.CountryID);

            builder.Entity<StateProvince>()
                .ToTable("StateProvinces")
                .HasMany(x => x.Cities)
                .WithOne(y => y.StateProvince)
                .HasForeignKey(y => y.StateProvinceID);

            builder.Entity<City>()
                .ToTable("Cities");
        }
    }
}
