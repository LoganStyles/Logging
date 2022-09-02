using Microsoft.EntityFrameworkCore;

namespace Logging
{

    public class ArtistsContext : DbContext
    {

        public ArtistsContext() { }

        public ArtistsContext(DbContextOptions<ArtistsContext> options) : base(options) { }

        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlite("data source=output/Artists.db")
                    .LogTo(
                        Console.WriteLine,
                        Microsoft.Extensions.Logging.LogLevel.Information
                    );
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

    }

}