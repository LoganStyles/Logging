using Microsoft.EntityFrameworkCore;

namespace Logging
{

    public class ArtistsContext : DbContext
    {

        private readonly StreamWriter _logWriter = new StreamWriter("logs.txt", true);
        public ArtistsContext() { }

        public ArtistsContext(DbContextOptions<ArtistsContext> options) : base(options) { }

        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlite("data source=output/Artists.db")
                    .LogTo(_logWriter.WriteLine);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public override void Dispose()
        {
            base.Dispose();
            _logWriter.Dispose();
        }

        public override async ValueTask DisposeAsync()
        {
            await base.DisposeAsync();
            await _logWriter.DisposeAsync();
        }
    }

}