using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

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
                        new[] { RelationalEventId.CommandExecuted },
                        // new[] { DbLoggerCategory.Database.Command.Name },
                        Microsoft.Extensions.Logging.LogLevel.Information
                    ).EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

    }

}